using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;
using SurrealDb.Net;

using System.Linq;

namespace JMMinistry.Application.Features.User.Queries.CheckDocumentExists
{
    public class CheckDocumentExistsHandler(ISurrealDbSession session)
        : IQueryHandler<CheckDocumentExistsQuery, DocumentCheckResultDto>
    {
        public async ValueTask<DocumentCheckResultDto> Handle(CheckDocumentExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                LET $user = (SELECT * FROM type::record('user', {request.Document}))[0];
                LET $has_cell = (SELECT count() > 0 FROM disciple_in WHERE in = type::record('user', {request.Document}))[0];

                RETURN IF $user != NONE THEN
                    {{
                        Exists: true,
                        HasCell: $has_cell,
                        Name: $user.name,
                        LastName: $user.last_name
                    }}
                ELSE
                    {{ Exists: false }}
                END;
            ", cancellationToken);

            return result.GetValue<DocumentCheckResultDto>(0) ?? throw new Exception("Unexpected null from DB");
        }
    }
}
