using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepCycles;

public class GetStepCyclesHandler(ISurrealDbSession session)
    : IQueryHandler<GetStepCyclesQuery, IList<StepCycleDto>>
{
    public async ValueTask<IList<StepCycleDto>> Handle(GetStepCyclesQuery request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            SELECT *, 
                   session_count,
                   enrolled_count,
                   (SELECT VALUE in FROM <-has)[0] AS disciple_step_id
            FROM cycle 
            WHERE id IN (SELECT VALUE out FROM has WHERE in = type::thing('disciple_step', {stepId}))
            ORDER BY start_date DESC;
        ", cancellationToken);

        var cycles = result.GetValue<List<StepCycleDto>>(0);

        return cycles ?? [];
    }
}
