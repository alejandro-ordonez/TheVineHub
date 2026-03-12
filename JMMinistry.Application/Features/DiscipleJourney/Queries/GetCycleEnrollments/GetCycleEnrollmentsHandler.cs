using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;
using Npgsql;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleEnrollments;

public class GetCycleEnrollmentsHandler(IJmDbContext dbContext)
    : IQueryHandler<GetCycleEnrollmentsQuery, IList<CycleEnrollmentDto>>
{
    public async ValueTask<IList<CycleEnrollmentDto>> Handle(GetCycleEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var leaderParam = new NpgsqlParameter("p_leader", request.RequestorId);
        var cycleParam = new NpgsqlParameter("p_cycle", request.CycleId);

        var rows = await dbContext.ExecuteTableFunctionAsync<CycleEnrollmentRow>(
            "SELECT * FROM get_cycle_enrollments(@p_leader, @p_cycle)",
            cancellationToken,
            leaderParam, cycleParam);

        return rows.Select(r => new CycleEnrollmentDto
        {
            Id = r.enrollment_id,
            DiscipleId = r.disciple_id,
            DiscipleName = r.disciple_name,
            CycleStaffId = r.cycle_staff_id,
            GuideName = r.guide_name,
            Status = (EnrollmentStatus)r.status,
            EnrolledAt = r.enrolled_at,
            AttendanceCount = r.attendance_count
        }).ToList();
    }
}
