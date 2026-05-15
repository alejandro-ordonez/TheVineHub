using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteStepCycle;

public class DeleteStepCycleHandler(ISurrealDbSession session)
    : ICommandHandler<DeleteStepCycleCommand>
{
    public async ValueTask<Unit> Handle(DeleteStepCycleCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            -- Verify cycle belongs to step
            LET $belongs = (SELECT count() > 0 FROM has WHERE in = type::thing('disciple_step', {stepId}) AND out = type::thing('cycle', {cycleId}))[0];
            
            IF !$belongs THEN
                THROW 'Cycle ' + {cycleId} + ' does not belong to step ' + {stepId};
            END;

            BEGIN TRANSACTION;
            
            -- Delete cycle
            DELETE type::thing('cycle', {cycleId});
            
            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
