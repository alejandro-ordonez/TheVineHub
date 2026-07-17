using TheVineHub.API.Features.Users;
using TheVineHub.API.Features.Users.Authenticate;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users.MarryLeaders;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using SurrealDb.Net.Models;
using System.Linq;

namespace TheVineHub.API.Features.Cells.RemoveDisciple
{
    public class RemoveDiscipleHandler(ISurrealDbSession session) : ICommandHandler<RemoveDiscipleCommand, IList<DiscipleDto>>
    {
        public async ValueTask<IList<DiscipleDto>> Handle(RemoveDiscipleCommand request, CancellationToken cancellationToken)
        {
            var cellId = ParseRecordId("cell", request.CellId);
            var userId = ParseRecordId("user", request.Document);

            var result = await session.Query(@$"
                {{
                    LET $user = {userId};
                    LET $cell = {cellId};

                    LET $relation = (SELECT * FROM disciple_in WHERE in = $user AND out = $cell);

                    IF array::len($relation) == 0 THEN
                        THROW 'This person does not belong to the given cell';
                    END;

                    DELETE disciple_in WHERE in = $user AND out = $cell;

                    RETURN (SELECT in.* FROM disciple_in WHERE out = $cell);
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new Exception($"SurrealDB Error: {errorRes.Details}");

                throw new Exception($"SurrealDB Error: {error}");
            }

            var disciples = result.GetValue<List<DiscipleDto>>(0);

            return disciples ?? new List<DiscipleDto>();
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
