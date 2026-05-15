using JMMinistry.Common;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized
{
    public class CellCheckIsAuthorizedHandler(ISurrealDbSession session) : IQueryHandler<CellCheckIsAuthorizedQuery, bool>
    {
        public async ValueTask<bool> Handle(CellCheckIsAuthorizedQuery request, CancellationToken cancellationToken)
        {
            var allowedRoles = new List<string>(request.AllowedRoles.Select(r => r.ToString()));
            allowedRoles.AddRange(new[] { Roles.Admin.ToString(), Roles.Attendance.ToString(), Roles.Cells.ToString() });

            var result = await session.Query(@$"
                LET $user_roles = (SELECT VALUE out.name FROM type::thing('user', {request.RequestorId})->member_of);
                LET $is_admin = (SELECT count() > 0 FROM $user_roles WHERE VALUE IN {allowedRoles})[0];
                
                IF $is_admin THEN
                    RETURN true;
                END;

                RETURN fn::is_leader(type::thing('user', {request.RequestorId}), type::thing('cell', {request.CellId}));
            ", cancellationToken);

            return result.GetValue<bool>(0);
        }
    }
}
