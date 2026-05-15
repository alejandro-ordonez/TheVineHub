using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteDiscipleStep;

public class DeleteDiscipleStepHandler(ISurrealDbSession session)
    : ICommandHandler<DeleteDiscipleStepCommand>
{
    public async ValueTask<Unit> Handle(DeleteDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;
            
            -- Delete step
            DELETE type::thing('disciple_step', {stepId});
            
            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
