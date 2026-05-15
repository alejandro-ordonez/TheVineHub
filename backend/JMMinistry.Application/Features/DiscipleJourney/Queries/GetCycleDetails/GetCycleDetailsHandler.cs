using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleDetails;

public class GetCycleDetailsHandler(ISurrealDbSession session)
    : IQueryHandler<GetCycleDetailsQuery, IList<CycleEnrollmentDto>>
{
    public async ValueTask<IList<CycleEnrollmentDto>> Handle(GetCycleDetailsQuery request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            LET $stepId = (SELECT VALUE in FROM type::thing('cycle', {cycleId})<-has)[0];
            
            SELECT 
                id,
                in AS disciple_id,
                (SELECT VALUE name + ' ' + last_name FROM in)[0] AS disciple_name,
                guide AS cycle_staff_id,
                (SELECT VALUE name + ' ' + last_name FROM guide)[0] AS guide_name,
                (SELECT VALUE status FROM completed WHERE in = $parent.in AND out = $stepId)[0] AS status,
                enrolled_at,
                (SELECT count() FROM attended WHERE in = $parent.in AND out IN (SELECT VALUE in FROM cycle_session<-session_of WHERE out = type::thing('cycle', {cycleId})))[0].count AS attendance_count
            FROM enrolled 
            WHERE out = type::thing('cycle', {cycleId});
        ", cancellationToken);

        var details = result.GetValue<List<CycleEnrollmentDto>>(0);

        return details ?? [];
    }
}
