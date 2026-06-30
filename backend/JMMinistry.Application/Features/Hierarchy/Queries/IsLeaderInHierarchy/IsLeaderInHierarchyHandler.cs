using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy
{
    public class IsLeaderInHierarchyHandler(ISurrealDbSession session)
        : IQueryHandler<IsLeaderInHierarchyQuery, bool>
    {
        public async ValueTask<bool> Handle(IsLeaderInHierarchyQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                RETURN fn::is_leader(type::record('user', {request.RequestorId}), type::record('user', {request.DiscipleId}));
            ", cancellationToken);

            return result.GetValue<bool>(0);
        }
    }
}
