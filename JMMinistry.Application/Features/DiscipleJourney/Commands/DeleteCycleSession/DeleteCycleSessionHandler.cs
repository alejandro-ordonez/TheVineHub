using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteCycleSession;

public class DeleteCycleSessionHandler(IJmDbContext dbContext)
    : ICommandHandler<DeleteCycleSessionCommand>
{
    public async ValueTask<Unit> Handle(DeleteCycleSessionCommand request, CancellationToken cancellationToken)
    {
        var session = await dbContext.CycleSessions
            .FirstOrDefaultAsync(s => s.Id == request.SessionId && s.StepCycleId == request.CycleId, cancellationToken)
            ?? throw new NotFoundException<CycleSession>(request.SessionId.ToString());

        dbContext.CycleSessions.Remove(session);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
