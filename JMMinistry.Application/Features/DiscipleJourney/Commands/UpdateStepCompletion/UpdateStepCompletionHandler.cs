using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
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

        // When abandoning, also abandon any active cycle enrollment for this step
        if (request.StepStatus == StepStatus.Abandoned)
        {
            var activeEnrollment = await dbContext.CycleEnrollments
                .FirstOrDefaultAsync(ce =>
                    ce.DiscipleId == request.DiscipleId &&
                    ce.Status == EnrollmentStatus.Active &&
                    ce.StepCycle!.DiscipleStepId == request.StepId,
                    cancellationToken);

            if (activeEnrollment is not null)
                activeEnrollment.Status = EnrollmentStatus.Abandoned;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
