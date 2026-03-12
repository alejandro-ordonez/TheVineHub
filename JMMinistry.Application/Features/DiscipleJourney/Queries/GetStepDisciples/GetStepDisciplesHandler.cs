using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using JMMinistry.Common.Dtos.User.Enums;
using Mediator;
using Npgsql;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepDisciples;

public class GetStepDisciplesHandler(IJmDbContext dbContext)
    : IQueryHandler<GetStepDisciplesQuery, IList<StepDisciplesByCellDto>>
{
    public async ValueTask<IList<StepDisciplesByCellDto>> Handle(GetStepDisciplesQuery request, CancellationToken cancellationToken)
    {
        var leaderParam = new NpgsqlParameter("p_leader", request.RequestorId);
        var stepParam = new NpgsqlParameter("p_step", request.StepId);
        var cellParam = new NpgsqlParameter("p_cell", NpgsqlTypes.NpgsqlDbType.Integer)
        {
            Value = (object?)request.CellId ?? DBNull.Value
        };

        var rows = await dbContext.ExecuteTableFunctionAsync<StepDiscipleRow>(
            "SELECT * FROM get_step_disciples(@p_leader, @p_step, @p_cell)",
            cancellationToken,
            leaderParam, stepParam, cellParam);

        var grouped = rows
            .GroupBy(r => new { r.disciple_cell_id, r.cell_name, r.cell_leader_name })
            .Select(g => new StepDisciplesByCellDto
            {
                CellId = g.Key.disciple_cell_id,
                CellName = g.Key.disciple_cell_id.HasValue ? g.Key.cell_name : string.Empty,
                LeaderName = g.Key.cell_leader_name,
                Disciples = g.Select(r => new StepDiscipleDto
                {
                    Document = r.disciple_id,
                    Name = r.disciple_name,
                    LastName = r.disciple_last_name,
                    Phone = r.disciple_phone,
                    Gender = (Gender)r.disciple_gender,
                    CellId = r.disciple_cell_id,
                    StepStatus = (Common.Dtos.DiscipleJourney.Enums.StepStatus)r.step_status,
                    LastUpdated = r.last_updated,
                    CycleEnrollmentSummary = r.cycle_name is not null ? new CycleEnrollmentSummaryDto
                    {
                        CycleName = r.cycle_name,
                        Status = (EnrollmentStatus)(r.enrollment_status ?? 0),
                        AttendanceCount = r.cycle_attendance_count ?? 0,
                        CycleEndDate = r.cycle_end_date ?? default,
                        MinAttendanceRequired = r.cycle_min_attendance ?? 0
                    } : null
                }).ToList()
            })
            .OrderBy(g => g.CellId is null)
            .ThenBy(g => g.CellName)
            .ToList();

        return grouped;
    }
}
