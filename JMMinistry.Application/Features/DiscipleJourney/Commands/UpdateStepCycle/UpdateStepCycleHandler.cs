using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;

public class UpdateStepCycleHandler(IJmDbContext dbContext)
    : ICommandHandler<UpdateStepCycleCommand, StepCycleDto>
{
    public async ValueTask<StepCycleDto> Handle(UpdateStepCycleCommand request, CancellationToken cancellationToken)
    {
        var cycle = await dbContext.StepCycles
            .FirstOrDefaultAsync(c => c.Id == request.CycleId && c.DiscipleStepId == request.StepId, cancellationToken)
            ?? throw new NotFoundException<StepCycle>(request.CycleId.ToString());

        cycle.Name = request.Name;
        cycle.StartDate = request.StartDate;
        cycle.EndDate = request.EndDate;
        cycle.MinAttendanceRequired = request.MinAttendanceRequired;
        cycle.IsOpen = request.IsOpen;
        cycle.EnrollmentDeadline = request.EnrollmentDeadline;

        await dbContext.SaveChangesAsync(cancellationToken);

        var sessionCount = await dbContext.CycleSessions.CountAsync(s => s.StepCycleId == cycle.Id, cancellationToken);
        var enrolledCount = await dbContext.CycleEnrollments.CountAsync(e => e.StepCycleId == cycle.Id, cancellationToken);

        return new StepCycleDto
        {
            Id = cycle.Id,
            DiscipleStepId = cycle.DiscipleStepId,
            Name = cycle.Name,
            StartDate = cycle.StartDate,
            EndDate = cycle.EndDate,
            MinAttendanceRequired = cycle.MinAttendanceRequired,
            IsOpen = cycle.IsOpen,
            EnrollmentDeadline = cycle.EnrollmentDeadline,
            SessionCount = sessionCount,
            EnrolledCount = enrolledCount
        };
    }
}
