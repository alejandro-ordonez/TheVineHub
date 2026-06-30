using JMMinistry.Application.Features.DiscipleJourney.Dtos;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;
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
            WHERE id IN (SELECT VALUE out FROM has WHERE in = type::record('disciple_step', {stepId}))
            ORDER BY end_date DESC;
        ", cancellationToken);

        var cycles = result.GetValue<List<StepCycleDto>>(0);

        return cycles ?? [];
    }
}
