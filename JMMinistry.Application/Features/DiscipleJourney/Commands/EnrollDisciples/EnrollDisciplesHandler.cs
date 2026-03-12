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

        var existingEnrollments = await dbContext.CycleEnrollments
            .Where(e => e.StepCycleId == request.CycleId && request.DiscipleIds.Contains(e.DiscipleId))
            .Select(e => e.DiscipleId)
            .ToListAsync(cancellationToken);

        var newDiscipleIds = request.DiscipleIds.Except(existingEnrollments).ToList();

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        var enrollments = newDiscipleIds.Select(discipleId => new CycleEnrollment
        {
            StepCycleId = request.CycleId,
            DiscipleId = discipleId,
            Status = EnrollmentStatus.Active,
            EnrolledAt = today
        });

        dbContext.CycleEnrollments.AddRange(enrollments);

        // Also create StepCompletion (InProgress) so disciples appear on the leader's step page
        var existingCompletions = await dbContext.StepCompletions
            .Where(sc => sc.DiscipleStepId == cycle.DiscipleStepId
                         && newDiscipleIds.Contains(sc.DiscipleId)
                         && sc.StepStatus != StepStatus.Abandoned)
            .Select(sc => sc.DiscipleId)
            .ToListAsync(cancellationToken);

        var needCompletion = newDiscipleIds.Except(existingCompletions).ToList();

        var completions = needCompletion.Select(discipleId => new StepCompletion
        {
            DiscipleStepId = cycle.DiscipleStepId,
            DiscipleId = discipleId,
            LeaderId = request.LeaderId,
            StepStatus = StepStatus.InProgress,
            DateCreated = today,
            LastUpdated = today,
            StepCycleId = cycle.Id
        });

        dbContext.StepCompletions.AddRange(completions);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
