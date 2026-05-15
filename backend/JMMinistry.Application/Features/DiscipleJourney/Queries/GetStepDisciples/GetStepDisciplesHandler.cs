using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepDisciples;

public class GetStepDisciplesHandler(ISurrealDbSession session)
    : IQueryHandler<GetStepDisciplesQuery, IList<StepDisciplesByCellDto>>
{
    public async ValueTask<IList<StepDisciplesByCellDto>> Handle(GetStepDisciplesQuery request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";
        var requestorId = request.RequestorId.StartsWith("user:") ? request.RequestorId : $"user:{request.RequestorId}";

        var result = await session.Query(@$"
            SELECT 
                id AS Document,
                name AS Name,
                last_name AS LastName,
                phone AS Phone,
                gender AS Gender,
                (SELECT VALUE out FROM ->disciple_in)[0] AS CellId,
                (SELECT VALUE in.name + ' ' + in.last_name FROM (SELECT VALUE out FROM ->disciple_in)-><-leads)[0] AS LeaderName,
                (SELECT VALUE name FROM (SELECT VALUE out FROM ->disciple_in))[0] AS CellName,
                (SELECT VALUE status FROM completed WHERE in = $parent.id AND out = type::thing('disciple_step', {stepId}))[0] AS StepStatus,
                (SELECT VALUE last_updated FROM completed WHERE in = $parent.id AND out = type::thing('disciple_step', {stepId}))[0] AS LastUpdated,
                (
                    SELECT 
                        out.name AS CycleName,
                        (SELECT VALUE status FROM completed WHERE in = $parent.$parent.id AND out = type::thing('disciple_step', {stepId}))[0] AS Status,
                        (SELECT count() FROM attended WHERE in = $parent.$parent.id AND out IN (SELECT VALUE in FROM cycle_session<-session_of WHERE out = $parent.out))[0].count AS AttendanceCount,
                        out.end_date AS CycleEndDate,
                        out.min_attendance AS MinAttendanceRequired
                    FROM enrolled 
                    WHERE in = $parent.id AND out IN (SELECT VALUE out FROM type::thing('disciple_step', {stepId})->has)
                )[0] AS CycleEnrollmentSummary
            FROM user 
            WHERE 
                -- Filter by cell if provided
                (IF {request.CellId} != NONE THEN (SELECT count() > 0 FROM ->disciple_in WHERE out = type::thing('cell', {request.CellId}))[0] ELSE true END)
                -- Is in the requestor's hierarchy
                AND fn::is_leader(type::thing('user', {requestorId}), id)
                -- Has some relation with the step (enrolled or completed)
                AND (
                    (SELECT count() > 0 FROM completed WHERE in = $parent.id AND out = type::thing('disciple_step', {stepId}))[0]
                    OR 
                    (SELECT count() > 0 FROM enrolled WHERE in = $parent.id AND out IN (SELECT VALUE out FROM type::thing('disciple_step', {stepId})->has))[0]
                );
        ", cancellationToken);

        var disciples = result.GetValue<List<StepDiscipleDto>>(0);

        /*
        var grouped = disciples
            .GroupBy(d => new { d.CellId, d.CellName, d.LeaderName })
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
