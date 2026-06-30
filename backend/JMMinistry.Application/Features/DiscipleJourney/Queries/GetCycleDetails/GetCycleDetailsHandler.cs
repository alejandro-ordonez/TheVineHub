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

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleDetails;

public class GetCycleDetailsHandler(ISurrealDbSession session)
    : IQueryHandler<GetCycleDetailsQuery, IList<CycleEnrollmentDto>>
{
    public async ValueTask<IList<CycleEnrollmentDto>> Handle(GetCycleDetailsQuery request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            LET $stepId = (SELECT VALUE in FROM type::record('cycle', {cycleId})<-has)[0];

            SELECT
                id,
                in AS disciple_id,
                (SELECT VALUE name + ' ' + last_name FROM in)[0] AS disciple_name,
                guide AS cycle_staff_id,
                (SELECT VALUE name + ' ' + last_name FROM guide)[0] AS guide_name,
                (SELECT VALUE status FROM completed WHERE in = $parent.in AND out = $stepId)[0] AS status,
                enrolled_at,
                (SELECT count() FROM attended WHERE in = $parent.in AND out IN (SELECT VALUE in FROM cycle_session<-session_of WHERE out = type::record('cycle', {cycleId})))[0].count AS attendance_count
            FROM enrolled
            WHERE out = type::record('cycle', {cycleId});
        ", cancellationToken);

        var details = result.GetValue<List<CycleEnrollmentDto>>(0);

        return details ?? [];
    }
}
