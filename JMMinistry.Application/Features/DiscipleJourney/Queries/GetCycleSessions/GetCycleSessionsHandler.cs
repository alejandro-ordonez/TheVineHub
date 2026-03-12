using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleSessions;

public class GetCycleSessionsHandler(IJmDbContext dbContext)
    : IQueryHandler<GetCycleSessionsQuery, IList<CycleSessionDto>>
{
    public async ValueTask<IList<CycleSessionDto>> Handle(GetCycleSessionsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.CycleSessions
            .Where(s => s.StepCycleId == request.CycleId)
            .OrderBy(s => s.Date)
            .Select(s => new CycleSessionDto
            {
                Id = s.Id,
                StepCycleId = s.StepCycleId,
                Date = s.Date,
                Topic = s.Topic
            })
            .ToListAsync(cancellationToken);
    }
}
