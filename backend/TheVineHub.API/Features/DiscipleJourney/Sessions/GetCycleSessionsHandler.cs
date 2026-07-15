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
using SurrealDb.Net.Models;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Sessions;

    public class GetCycleSessionsHandler(ISurrealDbSession session)
        : IQueryHandler<GetCycleSessionsQuery, IList<CycleSessionDto>>
    {
        public async ValueTask<IList<CycleSessionDto>> Handle(GetCycleSessionsQuery request, CancellationToken cancellationToken)
        {
            var cycleId = ParseRecordId("cycle", request.CycleId);

            var result = await session.Query(@$"
                SELECT 
                    type::string(id) AS id,
                    date,
                    topic,
                    type::string(cycle) AS step_cycle_id
                FROM cycle_session
                WHERE cycle = {cycleId}
                ORDER BY date ASC;
            ", cancellationToken);

            var sessions = result.GetValue<List<CycleSessionDto>>(0);

            return sessions ?? [];
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
