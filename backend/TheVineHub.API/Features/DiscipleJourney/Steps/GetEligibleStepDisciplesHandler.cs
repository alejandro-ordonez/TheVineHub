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

namespace TheVineHub.API.Features.DiscipleJourney.Steps;

public class GetEligibleStepDisciplesHandler(ISurrealDbSession session)
    : IQueryHandler<GetEligibleStepDisciplesQuery, IList<StepDisciplesByCellDto>>
{
    public async ValueTask<IList<StepDisciplesByCellDto>> Handle(GetEligibleStepDisciplesQuery request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";
        var requestorId = request.RequestorId.StartsWith("user:") ? request.RequestorId : $"user:{request.RequestorId}";

        var result = await session.Query(@$"
            -- Get step requirements
            LET $requirements = (SELECT VALUE out FROM type::record('disciple_step', {stepId})->requires);

            -- Find users who have completed all requirements
            -- And haven't started/completed the target step
            LET $eligibleDisciples = (
                SELECT
                    id AS Document,
                    name AS Name,
                    last_name AS LastName,
                    phone AS Phone,
                    gender AS Gender,
                    (SELECT VALUE out FROM ->disciple_in)[0] AS CellId,
                    (SELECT VALUE in.name + ' ' + in.last_name FROM (SELECT VALUE out FROM ->disciple_in)-><-leads)[0] AS LeaderName,
                    (SELECT VALUE name FROM (SELECT VALUE out FROM ->disciple_in))[0] AS CellName
                FROM user
                WHERE
                    -- Is in the requestor's hierarchy (recursive)
                    fn::is_leader(type::record('user', {requestorId}), id)
                    -- Has completed all requirements
                    AND (
                        SELECT count() FROM completed
                        WHERE in = $parent.id AND out IN $requirements AND status = 'Completed'
                    )[0].count = array::len($requirements)
                    -- Hasn't started target step
                    AND (
                        SELECT count() = 0 FROM completed
                        WHERE in = $parent.id AND out = type::record('disciple_step', {stepId}) AND status != 'Abandoned'
                    )[0]
            );

            RETURN $eligibleDisciples;
        ", cancellationToken);

        var disciples = result.GetValue<List<StepDiscipleDto>>(0);

        // Grouping in C# for consistency with legacy
        /*
        var grouped = disciples
            .GroupBy(d => new { d.CellId, d.Name, d.LeaderName })
            .Select(g => new StepDisciplesByCellDto
            {
                CellId = g.Key.CellId,
                CellName = g.Key.CellName ?? string.Empty,
                LeaderName = g.Key.LeaderName ?? string.Empty,
                Disciples = g.ToList()
            })
            .OrderBy(g => g.CellId is null)
            .ThenBy(g => g.CellName)
            .ToList();
        */

        return [];
    }
}
