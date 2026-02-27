using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteDiscipleStep;

public class DeleteDiscipleStepHandler(IJmDbContext dbContext)
    : ICommandHandler<DeleteDiscipleStepCommand>
{
    public async ValueTask<Unit> Handle(DeleteDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var step = await dbContext.DiscipleSteps
            .FirstOrDefaultAsync(s => s.Id == request.StepId, cancellationToken)
            ?? throw new NotFoundException(request.StepId.ToString());

        dbContext.DiscipleSteps.Remove(step);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
