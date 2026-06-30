using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteCycleSession;

public class DeleteCycleSessionHandler(ISurrealDbSession session)
    : ICommandHandler<DeleteCycleSessionCommand>
{
    public async ValueTask<Unit> Handle(DeleteCycleSessionCommand request, CancellationToken cancellationToken)
    {
        var sessionId = request.SessionId.StartsWith("cycle_session:") ? request.SessionId : $"cycle_session:{request.SessionId}";
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            -- Verify session belongs to cycle
            LET $belongs = (SELECT count() > 0 FROM session_of WHERE in = type::record('cycle_session', {sessionId}) AND out = type::record('cycle', {cycleId}))[0];

            IF !$belongs THEN
                THROW 'Session ' + {sessionId} + ' does not belong to cycle ' + {cycleId};
            END;

            BEGIN TRANSACTION;

            -- Delete session and its relationships
            DELETE type::record('cycle_session', {sessionId});

            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
