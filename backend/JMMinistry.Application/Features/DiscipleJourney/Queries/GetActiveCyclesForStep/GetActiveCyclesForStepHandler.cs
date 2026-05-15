using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetActiveCyclesForStep;

public class GetActiveCyclesForStepHandler(ISurrealDbSession session)
    : IQueryHandler<GetActiveCyclesForStepQuery, IList<StepCycleDto>>
{
    public async ValueTask<IList<StepCycleDto>> Handle(GetActiveCyclesForStepQuery request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            SELECT *, 
                   (SELECT VALUE count() FROM <-session_of)[0] AS session_count,
                   (SELECT VALUE count() FROM <-enrolled)[0] AS enrolled_count,
                   (SELECT VALUE in FROM <-has)[0] AS disciple_step_id
            FROM cycle 
            WHERE id IN (SELECT VALUE out FROM has WHERE in = type::thing('disciple_step', {stepId}))
            ORDER BY end_date DESC;
        ", cancellationToken);

        var cycles = result.GetValue<List<StepCycleDto>>(0);

        return cycles ?? [];
    }
}
