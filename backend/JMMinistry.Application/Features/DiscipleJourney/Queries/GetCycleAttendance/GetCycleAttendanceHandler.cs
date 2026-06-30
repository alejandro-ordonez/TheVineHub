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

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleAttendance;

public class GetCycleAttendanceHandler(ISurrealDbSession session)
    : IQueryHandler<GetCycleAttendanceQuery, IList<CycleAttendanceDto>>
{
    public async ValueTask<IList<CycleAttendanceDto>> Handle(GetCycleAttendanceQuery request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            -- Fetch all enrolled disciples for the cycle
            LET $disciples = (
                SELECT
                    in AS disciple_id,
                    (SELECT VALUE name + ' ' + last_name FROM in)[0] AS disciple_name,
                    -- Check status from completed relation for the step of this cycle
                    (SELECT count() > 0 FROM completed WHERE in = $parent.in AND out = (SELECT VALUE in FROM type::record('cycle', {cycleId})<-has)[0] AND status == 'Abandoned')[0] AS is_abandoned
                FROM enrolled
                WHERE out = type::record('cycle', {cycleId})
            );

            -- Fetch all sessions for the cycle
            LET $sessions = (
                SELECT
                    id AS session_id,
                    date AS session_date,
                    topic AS session_topic
                FROM cycle_session
                WHERE id IN (SELECT VALUE in FROM session_of WHERE out = type::record('cycle', {cycleId}))
                ORDER BY date ASC
            );

            -- Combine
            RETURN FOR $session IN $sessions {{
                LET $session_id = $session.session_id;
                RETURN {{
                    session_id: $session_id,
                    session_date: $session.session_date,
                    session_topic: $session.session_topic,
                    attendees: FOR $d IN $disciples {{
                        RETURN {{
                            disciple_id: $d.disciple_id,
                            disciple_name: $d.disciple_name,
                            is_abandoned: $d.is_abandoned,
                            attended: (SELECT count() > 0 FROM attended WHERE in = $d.disciple_id AND out = $session_id)[0]
                        }}
                    }}
                }}
            }};
        ", cancellationToken);

        var attendances = result.GetValue<List<CycleAttendanceDto>>(0);

        return attendances ?? [];
    }
}
