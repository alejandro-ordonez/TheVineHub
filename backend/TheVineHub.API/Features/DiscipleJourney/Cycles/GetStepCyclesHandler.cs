using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Sessions;
using TheVineHub.API.Features.DiscipleJourney.Staff;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Attendance;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles;

public class GetStepCyclesHandler(ISurrealDbSession session)
    : IQueryHandler<GetStepCyclesQuery, IList<StepCycleDto>>
{
    public async ValueTask<IList<StepCycleDto>> Handle(GetStepCyclesQuery request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

            var result = await session.Query(@$"
                SELECT
                    id,
                    name,
                    start_date,
                    end_date,
                    min_attendance,
                    is_open,
                    enrollment_deadline,
                    (SELECT count() FROM cycle_session WHERE cycle = $parent.id)[0].count AS session_count,
                    enrolled_count,
                    (SELECT VALUE in FROM <-has)[0] AS disciple_step_id
                FROM cycle
                WHERE id IN (SELECT VALUE out FROM has WHERE in = type::record('disciple_step', {stepId}))
                ORDER BY start_date DESC;
        ", cancellationToken);

        var cycles = result.GetValue<List<StepCycleDto>>(0);

        return cycles ?? [];
    }
}
