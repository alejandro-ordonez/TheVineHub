using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;

public class RecordCycleAttendanceHandler(ISurrealDbSession session)
    : ICommandHandler<RecordCycleAttendanceCommand>
{
    public async ValueTask<Unit> Handle(RecordCycleAttendanceCommand request, CancellationToken cancellationToken)
    {
        var sessionId = request.SessionId.StartsWith("cycle_session:") ? request.SessionId : $"cycle_session:{request.SessionId}";
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            -- Verify session belongs to cycle
            LET $session = (SELECT * FROM type::record('cycle_session', {sessionId}))[0];

            IF $session == NONE OR $session.cycle != type::record('cycle', {cycleId}) THEN
                THROW 'Session ' + {sessionId} + ' does not belong to cycle ' + {cycleId};
            END;

            BEGIN TRANSACTION;

            -- Remove existing attendances for this session
            DELETE attended_to WHERE out = type::record('cycle_session', {sessionId});

            -- Add new attendances
            FOR $discipleId IN {request.DiscipleIds} {{
                RELATE type::record('user', $discipleId)->attended_to->type::record('cycle_session', {sessionId});
            }};

            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
