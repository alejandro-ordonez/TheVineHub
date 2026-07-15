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

namespace TheVineHub.API.Features.DiscipleJourney.Staff
{
    public class GetCycleStaffHandler(ISurrealDbSession session)
        : IQueryHandler<GetCycleStaffQuery, IList<CycleStaffDto>>
    {
        public async ValueTask<IList<CycleStaffDto>> Handle(GetCycleStaffQuery request, CancellationToken cancellationToken)
        {
            var cycleId = ParseRecordId("cycle", request.CycleId);

            var result = await session.Query(@$"
                SELECT
                    type::string(id) AS id,
                    type::string(out) AS step_cycle_id,
                    type::string(in) AS person_id,
                    in.name + ' ' + in.last_name AS person_name,
                    role
                FROM guides
                WHERE out = {cycleId}
                ORDER BY role, person_name;
            ", cancellationToken);

            var staff = result.GetValue<List<CycleStaffDto>>(0);

            return staff ?? new List<CycleStaffDto>();
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
