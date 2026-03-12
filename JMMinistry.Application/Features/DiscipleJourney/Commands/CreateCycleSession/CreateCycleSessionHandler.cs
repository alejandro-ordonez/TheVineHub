using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;

public class CreateCycleSessionHandler(IJmDbContext dbContext)
    : ICommandHandler<CreateCycleSessionCommand, CycleSessionDto>
{
    public async ValueTask<CycleSessionDto> Handle(CreateCycleSessionCommand request, CancellationToken cancellationToken)
    {
        var session = new CycleSession
        {
            StepCycleId = request.CycleId,
            Date = request.Date,
            Topic = request.Topic
        };

        dbContext.CycleSessions.Add(session);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CycleSessionDto
        {
            Id = session.Id,
            StepCycleId = session.StepCycleId,
            Date = session.Date,
            Topic = session.Topic
        };
    }
}
