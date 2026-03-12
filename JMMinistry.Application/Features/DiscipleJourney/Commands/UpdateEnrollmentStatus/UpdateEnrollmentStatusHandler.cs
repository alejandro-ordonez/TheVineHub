using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;

public class UpdateEnrollmentStatusHandler(IJmDbContext dbContext)
    : ICommandHandler<UpdateEnrollmentStatusCommand>
{
    public async ValueTask<Unit> Handle(UpdateEnrollmentStatusCommand request, CancellationToken cancellationToken)
    {
        var enrollment = await dbContext.CycleEnrollments
            .FirstOrDefaultAsync(e => e.Id == request.EnrollmentId && e.StepCycleId == request.CycleId, cancellationToken)
            ?? throw new NotFoundException<CycleEnrollment>(request.EnrollmentId.ToString());

        enrollment.Status = (EnrollmentStatus)(int)request.Status;
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
