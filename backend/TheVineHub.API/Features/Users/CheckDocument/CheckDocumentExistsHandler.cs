using TheVineHub.API.Features.Users;
using TheVineHub.API.Features.Users.Authenticate;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users.MarryLeaders;
using Mediator;
using SurrealDb.Net;

using SurrealDb.Net.Models.Response;
using System.Linq;

namespace TheVineHub.API.Features.Users.CheckDocument
{
    public class CheckDocumentExistsHandler(ISurrealDbSession session)
        : IQueryHandler<CheckDocumentExistsQuery, DocumentCheckResultDto>
    {
        public async ValueTask<DocumentCheckResultDto> Handle(CheckDocumentExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                {{
                    LET $user = (SELECT * FROM type::record('user', {request.Document}))[0];
                    LET $has_cell = (SELECT VALUE count() > 0 FROM disciple_in WHERE in = type::record('user', {request.Document}))[0] OR false;

                    RETURN IF $user != NONE THEN
                        {{
                            exists: true,
                            has_cell: $has_cell,
                            name: $user.name,
                            last_name: $user.last_name
                        }}
                    ELSE
                        {{ exists: false }}
                    END;
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            return result.GetValue<DocumentCheckResultDto>(0) ?? throw new Exception("Unexpected null from DB");
        }
    }
}
