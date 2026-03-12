using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepCycles;

public class GetStepCyclesHandler(IJmDbContext dbContext)
    : IQueryHandler<GetStepCyclesQuery, IList<StepCycleDto>>
{
    public async ValueTask<IList<StepCycleDto>> Handle(GetStepCyclesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.StepCycles
            .Where(c => c.DiscipleStepId == request.StepId)
            .OrderByDescending(c => c.StartDate)
            .Select(c => new StepCycleDto
            {
                Id = c.Id,
                DiscipleStepId = c.DiscipleStepId,
                Name = c.Name,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                MinAttendanceRequired = c.MinAttendanceRequired,
                IsOpen = c.IsOpen,
                EnrollmentDeadline = c.EnrollmentDeadline,
                SessionCount = c.Sessions.Count,
                EnrolledCount = c.Enrollments.Count
            })
            .ToListAsync(cancellationToken);
    }
}
