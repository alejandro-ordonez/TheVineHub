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
            LET $belongs = (SELECT count() > 0 FROM session_of WHERE in = type::thing('cycle_session', {sessionId}) AND out = type::thing('cycle', {cycleId}))[0];
            
            IF !$belongs THEN
                THROW 'Session ' + {sessionId} + ' does not belong to cycle ' + {cycleId};
            END;

            BEGIN TRANSACTION;
            
            -- Remove existing attendances for this session
            DELETE attended WHERE out = type::thing('cycle_session', {sessionId});

            -- Add new attendances
            FOR $discipleId IN {request.DiscipleIds} {{
                RELATE type::thing('user', $discipleId)->attended->type::thing('cycle_session', {sessionId});
            }};
            
            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
