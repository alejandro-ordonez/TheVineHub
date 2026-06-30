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

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleEnrollments;

public class GetCycleEnrollmentsHandler(ISurrealDbSession session)
    : IQueryHandler<GetCycleEnrollmentsQuery, IList<CycleEnrollmentDto>>
{
    public async ValueTask<IList<CycleEnrollmentDto>> Handle(GetCycleEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var requestorId = request.RequestorId.StartsWith("user:") ? request.RequestorId : $"user:{request.RequestorId}";

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
            WHERE out = type::record('cycle', {cycleId})
            AND (
                guide = type::record('user', {requestorId})
                OR
                -- If coordinator, show all
                (SELECT count() > 0 FROM guides WHERE in = type::record('user', {requestorId}) AND out = type::record('cycle', {cycleId}) AND role = 'Coordinator')[0]
                OR
                -- If admin
                (SELECT count() > 0 FROM type::record('user', {requestorId})->member_of WHERE out.name = 'Admin')[0]
            );
        ", cancellationToken);

        var enrollments = result.GetValue<List<CycleEnrollmentDto>>(0);

        return enrollments ?? [];
    }
}
