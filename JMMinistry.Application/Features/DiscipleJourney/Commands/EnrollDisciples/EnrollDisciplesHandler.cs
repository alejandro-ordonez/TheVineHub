using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;

public class EnrollDisciplesHandler(IJmDbContext dbContext)
    : ICommandHandler<EnrollDisciplesCommand>
{
    public async ValueTask<Unit> Handle(EnrollDisciplesCommand request, CancellationToken cancellationToken)
    {
        var cycle = await dbContext.StepCycles
            .FirstOrDefaultAsync(c => c.Id == request.CycleId, cancellationToken)
            ?? throw new NotFoundException<StepCycle>(request.CycleId.ToString());

        if (!cycle.IsOpen)
            throw new InvalidOperationException("Cycle is not open for enrollment.");

        if (cycle.EnrollmentDeadline.HasValue && DateOnly.FromDateTime(DateTime.UtcNow) > cycle.EnrollmentDeadline.Value)
            throw new InvalidOperationException("Enrollment deadline has passed.");

        // Resolve status: active cycle → InitialStatus ?? Enrolled; inactive → Completed
        var resolvedStatus = cycle.IsOpen
            ? request.InitialStatus ?? StepStatus.Enrolled
            : StepStatus.Completed;

        // One-enrollment-per-step guard: skip disciples who already have a non-abandoned enrollment for this step (any cycle)
        var alreadyEnrolledIds = await dbContext.CycleEnrollments
            .Include(e => e.StepCompletion)
            .Where(e => e.StepCycle!.DiscipleStepId == cycle.DiscipleStepId
                        && request.DiscipleIds.Contains(e.DiscipleId)
                        && e.StepCompletion!.StepStatus != StepStatus.Abandoned)
            .Select(e => e.DiscipleId)
            .Distinct()
            .ToListAsync(cancellationToken);

        var newDiscipleIds = request.DiscipleIds.Except(alreadyEnrolledIds).ToList();

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        // Find existing non-abandoned StepCompletions for reuse
        var existingCompletions = await dbContext.StepCompletions
            .Where(sc => sc.DiscipleStepId == cycle.DiscipleStepId
                         && newDiscipleIds.Contains(sc.DiscipleId)
                         && sc.StepStatus != StepStatus.Abandoned)
            .ToDictionaryAsync(sc => sc.DiscipleId, cancellationToken);

        foreach (var discipleId in newDiscipleIds)
        {
            StepCompletion completion;

            if (existingCompletions.TryGetValue(discipleId, out var existing))
            {
                existing.StepStatus = resolvedStatus;
                existing.LastUpdated = today;
                completion = existing;
            }
            else
            {
                completion = new StepCompletion
                {
                    DiscipleStepId = cycle.DiscipleStepId,
                    DiscipleId = discipleId,
                    LeaderId = request.LeaderId,
                    StepStatus = resolvedStatus,
                    DateCreated = today,
                    LastUpdated = today,
                    StepCycleId = cycle.Id
                };
                dbContext.StepCompletions.Add(completion);
            }

            dbContext.CycleEnrollments.Add(new CycleEnrollment
            {
                StepCycleId = request.CycleId,
                DiscipleId = discipleId,
                EnrolledAt = today,
                StepCompletion = completion
            });
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
