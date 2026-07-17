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
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles
{
    public class GetCycleDetailsHandler(ISurrealDbSession session)
        : IQueryHandler<GetCycleDetailsQuery, IList<CycleEnrollmentDto>>
    {
        public async ValueTask<IList<CycleEnrollmentDto>> Handle(GetCycleDetailsQuery request, CancellationToken cancellationToken)
        {
            var cycleId = ParseRecordId("cycle", request.CycleId);

            var result = await session.Query(@$"
                LET $stepId = (SELECT VALUE in FROM {cycleId}<-has)[0];

                SELECT
                    type::string(id) AS id,
                    type::string(in) AS disciple_id,
                    in.name + ' ' + in.last_name AS disciple_name,
                    type::string(guide) AS cycle_staff_id,
                    (guide.name ?? '') + ' ' + (guide.last_name ?? '') AS guide_name,
                    (SELECT VALUE status FROM completed WHERE in = $parent.in AND out = $stepId)[0] AS status,
                    date_created AS enrolled_at,
                    ((SELECT count() FROM attended_to WHERE in = $parent.in AND out IN (SELECT VALUE id FROM cycle_session WHERE cycle = {cycleId}))[0].count ?? 0) AS attendance_count
                FROM enrolled
                WHERE out = {cycleId};
            ", cancellationToken);

            var details = result.GetValue<List<CycleEnrollmentDto>>(1);

            return details ?? [];
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
