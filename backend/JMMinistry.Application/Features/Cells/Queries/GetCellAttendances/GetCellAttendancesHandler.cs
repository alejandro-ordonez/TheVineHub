using JMMinistry.Application.Features.Cells.Dtos;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;

namespace JMMinistry.Application.Features.Cells.Queries.GetCellAttendances
{
    public class GetCellAttendancesHandler(ISurrealDbSession session) : IQueryHandler<GetCellAttendancesQuery, IList<CellAttendanceDto>>
    {
        public async ValueTask<IList<CellAttendanceDto>> Handle(GetCellAttendancesQuery request, CancellationToken cancellationToken)
        {
            var cellId = request.CellId.StartsWith("cell:") ? request.CellId : $"cell:{request.CellId}";
            var requestorId = request.RequestorId.StartsWith("user:") ? request.RequestorId : $"user:{request.RequestorId}";

            var result = await session.Query(@$"
                -- Authorization check
                LET $is_authorized = (
                    fn::is_leader(type::record('user', {requestorId}), type::record('cell', {cellId}))
                    OR fn::is_authorized(type::record('user', {requestorId}), ['Admin', 'Attendance', 'Cells'])
                );

                IF !$is_authorized THEN
                    THROW 'Not authorized to view attendance for this cell';
                END;

                -- Fetch disciples
                LET $disciples = (SELECT VALUE in FROM disciple_in WHERE out = type::record('cell', {cellId}));

                -- Fetch attendances with automatic missing attendees calculation
                SELECT *,
                       topic AS notes,
                       (SELECT * FROM user WHERE id IN (SELECT VALUE in FROM <-attended_to WHERE out = $parent.id)) AS attendees,
                       (SELECT * FROM user WHERE id IN array::diff($disciples, (SELECT VALUE in FROM <-attended_to WHERE out = $parent.id))) AS missing_attendees
                FROM cell_meeting
                WHERE cell = type::record('cell', {cellId})
                ORDER BY date DESC
                LIMIT 40;
            ", cancellationToken);

            var attendancesList = result.GetValue<List<CellAttendanceDto>>(0);

            return attendancesList ?? [];
        }
    }
}
