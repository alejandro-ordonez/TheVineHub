using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteStepCycle;

public class DeleteStepCycleHandler(IJmDbContext dbContext)
    : ICommandHandler<DeleteStepCycleCommand>
{
    public async ValueTask<Unit> Handle(DeleteStepCycleCommand request, CancellationToken cancellationToken)
    {
        var cycle = await dbContext.StepCycles
            .FirstOrDefaultAsync(c => c.Id == request.CycleId && c.DiscipleStepId == request.StepId, cancellationToken)
            ?? throw new NotFoundException<StepCycle>(request.CycleId.ToString());

        dbContext.StepCycles.Remove(cycle);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
