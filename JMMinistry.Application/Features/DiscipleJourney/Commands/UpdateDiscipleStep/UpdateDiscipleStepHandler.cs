using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;

public class UpdateDiscipleStepHandler(IJmDbContext dbContext, AppMapper mapper)
    : ICommandHandler<UpdateDiscipleStepCommand, DiscipleStepDto>
{
    public async ValueTask<DiscipleStepDto> Handle(UpdateDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var step = await dbContext.DiscipleSteps
            .Include(s => s.DiscipleStepRequirements)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException<DiscipleStep>(request.Id.ToString());

        step.Name = request.Name;
        step.Description = request.Description;
        step.StepCategory = request.StepCategory;
        step.ParentStepId = request.ParentStepId;

        var requirements = request.RequirementIds.Count > 0
            ? await dbContext.DiscipleSteps
                .Where(s => request.RequirementIds.Contains(s.Id))
                .ToListAsync(cancellationToken)
            : [];

        step.DiscipleStepRequirements.Clear();
        foreach (var req in requirements)
            step.DiscipleStepRequirements.Add(req);

        await dbContext.SaveChangesAsync(cancellationToken);

        return mapper.DiscipleStepToDiscipleStepDto(step);
    }
}
