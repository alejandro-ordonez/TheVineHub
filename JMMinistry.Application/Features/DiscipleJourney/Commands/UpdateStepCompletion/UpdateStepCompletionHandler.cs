using JMMinistry.Application.Services;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion;

public class UpdateStepCompletionHandler(IJmDbContext dbContext)
    : ICommandHandler<UpdateStepCompletionCommand>
{
    public async ValueTask<Unit> Handle(UpdateStepCompletionCommand request, CancellationToken cancellationToken)
    {
        var completion = await dbContext.StepCompletions
            .FirstOrDefaultAsync(sc =>
                sc.DiscipleStepId == request.StepId &&
                sc.DiscipleId == request.DiscipleId,
                cancellationToken)
            ?? throw new KeyNotFoundException($"StepCompletion not found for step {request.StepId} and disciple {request.DiscipleId}");

        completion.StepStatus = request.StepStatus;
        completion.LastUpdated = request.CompletionDate ?? DateOnly.FromDateTime(DateTime.UtcNow);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
