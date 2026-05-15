using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;

public class CreateCycleSessionHandler(ISurrealDbSession session)
    : ICommandHandler<CreateCycleSessionCommand, CycleSessionDto>
{
    public async ValueTask<CycleSessionDto> Handle(CreateCycleSessionCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;
            
            LET $session = (CREATE cycle_session SET 
                date = {request.Date.ToDateTime(TimeOnly.MinValue)}, 
                topic = {request.Topic})[0];
            
            RELATE $session.id->session_of->type::thing('cycle', {cycleId});
            
            COMMIT TRANSACTION;
            
            RETURN {{
                id: $session.id,
                step_cycle_id: type::thing('cycle', {cycleId}),
                date: $session.date,
                topic: $session.topic
            }};
        ", cancellationToken);

        return result.GetValue<CycleSessionDto>(0);
    }
}
