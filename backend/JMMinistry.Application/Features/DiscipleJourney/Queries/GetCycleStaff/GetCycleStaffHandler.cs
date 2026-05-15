using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleStaff;

public class GetCycleStaffHandler(ISurrealDbSession session)
    : IQueryHandler<GetCycleStaffQuery, IList<CycleStaffDto>>
{
    public async ValueTask<IList<CycleStaffDto>> Handle(GetCycleStaffQuery request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            SELECT 
                id,
                out AS step_cycle_id,
                in AS person_id,
                (SELECT VALUE name + ' ' + last_name FROM in)[0] AS person_name,
                role
            FROM guides 
            WHERE out = type::thing('cycle', {cycleId})
            ORDER BY role, person_name;
        ", cancellationToken);

        var staff = result.GetValue<List<CycleStaffDto>>(0);

        return staff ?? new List<CycleStaffDto>();
    }
}
