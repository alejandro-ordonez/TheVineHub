using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;

public class AssignGuideHandler(IJmDbContext dbContext)
    : ICommandHandler<AssignGuideCommand>
{
    public async ValueTask<Unit> Handle(AssignGuideCommand request, CancellationToken cancellationToken)
    {
        var staffExists = await dbContext.CycleStaff
            .AnyAsync(s => s.Id == request.CycleStaffId && s.StepCycleId == request.CycleId, cancellationToken);

        if (!staffExists)
            throw new NotFoundException<CycleStaff>(request.CycleStaffId.ToString());

        var enrollments = await dbContext.CycleEnrollments
            .Where(e => e.StepCycleId == request.CycleId && request.EnrollmentIds.Contains(e.Id))
            .ToListAsync(cancellationToken);

        foreach (var enrollment in enrollments)
            enrollment.CycleStaffId = request.CycleStaffId;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
