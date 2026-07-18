using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;
using SurrealDb.Net.Models;
using SurrealDb.Net.Models.Response;

namespace TheVineHub.API.Features.DiscipleJourney.Staff
{
    public class RemoveCycleStaffHandler(ISurrealDbSession session)
        : ICommandHandler<RemoveCycleStaffCommand>
    {
        public async ValueTask<Unit> Handle(RemoveCycleStaffCommand request, CancellationToken cancellationToken)
        {
            var staffId = ParseRecordId("guides", request.StaffId);

            var result = await session.Query(@$"
                {{
                    DELETE {staffId};
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            return Unit.Value;
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
