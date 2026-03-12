using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;

public class CreateStepCycleHandler(IJmDbContext dbContext)
    : ICommandHandler<CreateStepCycleCommand, StepCycleDto>
{
    public async ValueTask<StepCycleDto> Handle(CreateStepCycleCommand request, CancellationToken cancellationToken)
    {
        var cycle = new StepCycle
        {
            Name = request.Name,
            DiscipleStepId = request.StepId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            MinAttendanceRequired = request.MinAttendanceRequired,
            EnrollmentDeadline = request.EnrollmentDeadline,
            IsOpen = true
        };

        dbContext.StepCycles.Add(cycle);
        await dbContext.SaveChangesAsync(cancellationToken);

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
            SessionCount = 0,
            EnrolledCount = 0
        };
    }
}
