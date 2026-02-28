using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetDiscipleSteps
{
    public class GetDiscipleStepsHandler(IJmDbContext dbContext, AppMapper mapper)
        : IQueryHandler<GetDiscipleStepsQuery, IList<DiscipleStepDto>>
    {
        public async ValueTask<IList<DiscipleStepDto>> Handle(GetDiscipleStepsQuery request, CancellationToken cancellationToken)
        {
            var steps = await dbContext.DiscipleSteps
                .Include(s => s.DiscipleStepRequirements)
                .Include(s => s.SubSteps)
                    .ThenInclude(sub => sub.DiscipleStepRequirements)
                .Where(s => s.ParentStepId == null)
                .OrderBy(s => s.StepCategory)
                .ThenBy(s => s.Id)
                .ToListAsync(cancellationToken);

            return mapper.DiscipleStepListToDiscipleStepDtoList(steps);
        }
    }
}
