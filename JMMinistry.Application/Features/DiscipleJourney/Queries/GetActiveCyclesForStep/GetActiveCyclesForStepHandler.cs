using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetActiveCyclesForStep;

public class GetActiveCyclesForStepHandler(IJmDbContext dbContext)
    : IQueryHandler<GetActiveCyclesForStepQuery, IList<StepCycleDto>>
{
    public async ValueTask<IList<StepCycleDto>> Handle(GetActiveCyclesForStepQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.StepCycles
            .Where(c => c.DiscipleStepId == request.StepId)
            .OrderByDescending(c => c.EndDate)
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
