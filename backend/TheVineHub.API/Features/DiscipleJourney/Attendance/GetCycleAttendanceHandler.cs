using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models;
using SurrealDb.Net.Models.Response;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheVineHub.API.Features.DiscipleJourney.Attendance
{
    public class GetCycleAttendanceHandler(ISurrealDbSession session)
        : IQueryHandler<GetCycleAttendanceQuery, IList<CycleAttendanceDto>>
    {
        private sealed class DbDisciple
        {
            [Column("disciple_id")]
            public string? DiscipleId { get; set; }
            [Column("disciple_name")]
            public string? DiscipleName { get; set; }
            [Column("is_abandoned")]
            public bool IsAbandoned { get; set; }
        }

        private sealed class DbSession
        {
            [Column("id")]
            public string? Id { get; set; }
            [Column("date")]
            public DateOnly Date { get; set; }
            [Column("topic")]
            public string? Topic { get; set; }
        }

        private sealed class DbAttendance
        {
            [Column("in")]
            public string? In { get; set; }
            [Column("out")]
            public string? Out { get; set; }
        }

        public async ValueTask<IList<CycleAttendanceDto>> Handle(GetCycleAttendanceQuery request, CancellationToken cancellationToken)
        {
            var cycleId = ParseRecordId("cycle", request.CycleId);

            var result = await session.Query(@$"
                SELECT
                    type::string(in) AS disciple_id,
                    ((in.name ?? '') + ' ' + (in.last_name ?? '')) AS disciple_name,
                    ((SELECT count() > 0 FROM completed
                        WHERE in = $parent.in
                          AND out = (SELECT VALUE in FROM {cycleId}<-has)[0]
                          AND status == 'Abandoned')[0] ?? false) AS is_abandoned
                FROM enrolled
                WHERE out = {cycleId};

                SELECT
                    type::string(id) AS id,
                    date,
                    topic
                FROM cycle_session
                WHERE cycle = {cycleId}
                ORDER BY date ASC;

                SELECT
                    type::string(in) AS in,
                    type::string(out) AS out
                FROM attended_to
                WHERE out IN (SELECT VALUE id FROM cycle_session WHERE cycle = {cycleId});
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");
                throw new DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            var dbDisciples = result.GetValue<List<DbDisciple>>(0) ?? [];
            var dbSessions = result.GetValue<List<DbSession>>(1) ?? [];
            var dbAttendances = result.GetValue<List<DbAttendance>>(2) ?? [];

            var attendances = dbSessions
                .Where(s => s.Id != null)
                .Select(s => new CycleAttendanceDto
                {
                    SessionId = s.Id!.ToString(),
                    SessionDate = s.Date,
                    SessionTopic = s.Topic ?? "",
                    Attendees = dbDisciples
                        .Where(d => d.DiscipleId != null)
                        .Select(d => {
                            var isAttended = dbAttendances.Any(a => 
                                a.In != null && 
                                a.Out != null &&
                                a.In.ToString() == d.DiscipleId && 
                                a.Out.ToString() == s.Id.ToString()
                            );
                            return new CycleAttendeeDto
                            {
                                DiscipleId = d.DiscipleId!,
                                DiscipleName = d.DiscipleName ?? "",
                                IsAbandoned = d.IsAbandoned,
                                Attended = isAttended
                            };
                        }).ToList()
                }).ToList();

            return attendances;
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}

