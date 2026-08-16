using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models;
using SurrealDb.Net.Models.Response;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Attendance;

public class RecordCycleAttendanceHandler(ISurrealDbSession session)
    : ICommandHandler<RecordCycleAttendanceCommand>
{
    public async ValueTask<Unit> Handle(RecordCycleAttendanceCommand request, CancellationToken cancellationToken)
    {
        // Build typed RecordIds — avoids "table:table:id" double-prefix bug from type::record()
        var sessionIdStr = request.SessionId.StartsWith("cycle_session:") ? request.SessionId : $"cycle_session:{request.SessionId}";
        var cycleIdStr   = request.CycleId.StartsWith("cycle:")          ? request.CycleId   : $"cycle:{request.CycleId}";

        var sessionRecordId = RecordId.From("cycle_session", sessionIdStr.Split(':', 2)[1]);
        var cycleRecordId   = RecordId.From("cycle",         cycleIdStr.Split(':', 2)[1]);

        var result = await session.Query(@$"
            -- Verify session belongs to cycle
            LET $cs = (SELECT * FROM {sessionRecordId})[0];

            IF $cs == NONE OR $cs.cycle != {cycleRecordId} THEN
                THROW 'Session does not belong to cycle';
            END;

            -- Remove existing attendances for this session then re-insert
            DELETE attended_to WHERE out = {sessionRecordId};

            FOR $discipleId IN {request.DiscipleIds} {{
                LET $user = type::record('user', $discipleId);
                RELATE $user->attended_to->{sessionRecordId};
            }};
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
}
