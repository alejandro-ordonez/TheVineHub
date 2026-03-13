using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using Npgsql;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleAttendance;

public class GetCycleAttendanceHandler(IJmDbContext dbContext)
    : IQueryHandler<GetCycleAttendanceQuery, IList<CycleAttendanceDto>>
{
    public async ValueTask<IList<CycleAttendanceDto>> Handle(GetCycleAttendanceQuery request, CancellationToken cancellationToken)
    {
        var cycleParam = new NpgsqlParameter("p_cycle", request.CycleId);

        var rows = await dbContext.ExecuteTableFunctionAsync<CycleAttendanceRow>(
            "SELECT * FROM get_cycle_attendance(@p_cycle)",
            cancellationToken,
            cycleParam);

        return rows
            .GroupBy(r => new { r.session_id, r.session_date, r.session_topic })
            .OrderBy(g => g.Key.session_date)
            .Select(g => new CycleAttendanceDto
            {
                SessionId = g.Key.session_id,
                SessionDate = g.Key.session_date,
                SessionTopic = g.Key.session_topic,
                Attendees = g.Select(r => new CycleAttendeeDto
                {
                    DiscipleId = r.disciple_id,
                    DiscipleName = r.disciple_name,
                    Attended = r.attended,
                    IsAbandoned = r.is_abandoned
                }).ToList()
            })
            .ToList();
    }
}
