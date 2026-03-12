using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;

public class CreateDiscipleStepHandler(IJmDbContext dbContext, AppMapper mapper)
    : ICommandHandler<CreateDiscipleStepCommand, DiscipleStepDto>
{
    public async ValueTask<DiscipleStepDto> Handle(CreateDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var requirements = request.RequirementIds.Count > 0
            ? await dbContext.DiscipleSteps
                .Where(s => request.RequirementIds.Contains(s.Id))
                .ToListAsync(cancellationToken)
            : [];

        var step = new DiscipleStep
        {
            Name = request.Name,
            Description = request.Description,
            StepCategory = request.StepCategory,
            RequiresCycle = request.RequiresCycle,
            ParentStepId = request.ParentStepId,
            DiscipleStepRequirements = requirements
        };

        dbContext.DiscipleSteps.Add(step);
        await dbContext.SaveChangesAsync(cancellationToken);

        return mapper.DiscipleStepToDiscipleStepDto(step);
    }
}
