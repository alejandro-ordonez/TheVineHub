using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;
using SurrealDb.Net.Models;
using SurrealDb.Net.Models.Response;

namespace TheVineHub.API.Features.DiscipleJourney.Sessions
{
    public class DeleteCycleSessionHandler(ISurrealDbSession session)
        : ICommandHandler<DeleteCycleSessionCommand>
    {
        public async ValueTask<Unit> Handle(DeleteCycleSessionCommand request, CancellationToken cancellationToken)
        {
            var sessionId = ParseRecordId("cycle_session", request.SessionId);
            var cycleId = ParseRecordId("cycle", request.CycleId);

            var result = await session.Query(@$"
                {{
                    LET $session = {sessionId};
                    LET $cycle = {cycleId};
                    LET $belongs = (SELECT count() > 0 FROM cycle_session WHERE id = $session AND cycle = $cycle)[0];

                    IF !$belongs THEN
                        THROW 'Session ' + type::string($session) + ' does not belong to cycle ' + type::string($cycle);
                    END;

                    DELETE $session;
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new DatabaseExecutionException($"SurrealDB Error: {error}");
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
