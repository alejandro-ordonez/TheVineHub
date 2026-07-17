using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles;

public class DeleteStepCycleHandler(ISurrealDbSession session)
    : ICommandHandler<DeleteStepCycleCommand>
{
    public async ValueTask<Unit> Handle(DeleteStepCycleCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            -- Verify cycle belongs to step
            LET $belongs = (SELECT count() > 0 FROM has WHERE in = type::record('disciple_step', {stepId}) AND out = type::record('cycle', {cycleId}))[0];

            IF !$belongs THEN
                THROW 'Cycle ' + {cycleId} + ' does not belong to step ' + {stepId};
            END;

            BEGIN TRANSACTION;

            -- Delete cycle
            DELETE type::record('cycle', {cycleId});

            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
