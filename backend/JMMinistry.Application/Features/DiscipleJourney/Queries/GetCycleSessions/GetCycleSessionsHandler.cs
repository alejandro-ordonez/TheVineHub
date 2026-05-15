using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleSessions;

public class GetCycleSessionsHandler(ISurrealDbSession session)
    : IQueryHandler<GetCycleSessionsQuery, IList<CycleSessionDto>>
{
    public async ValueTask<IList<CycleSessionDto>> Handle(GetCycleSessionsQuery request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            SELECT *, 
                   (SELECT VALUE out FROM ->session_of)[0] AS step_cycle_id
            FROM cycle_session 
            WHERE id IN (SELECT VALUE in FROM session_of WHERE out = type::thing('cycle', {cycleId}))
            ORDER BY date ASC;
        ", cancellationToken);

        var sessions = result.GetValue<List<CycleSessionDto>>(0);

        return sessions ?? [];
    }
}
