using TheVineHub.API.Features.Cells;
using TheVineHub.API.Features.Cells.AddDisciples;
using TheVineHub.API.Features.Users;
using TheVineHub.API.Features.Users.Authenticate;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users.MarryLeaders;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models;
using SurrealDb.Net.Models.Response;

namespace TheVineHub.API.Features.Cells.GetCellAttendances
{
    public class GetCellAttendancesHandler(ISurrealDbSession session) : IQueryHandler<GetCellAttendancesQuery, IList<CellAttendanceDto>>
    {
        public async ValueTask<IList<CellAttendanceDto>> Handle(GetCellAttendancesQuery request, CancellationToken cancellationToken)
        {
            var cellId = ParseRecordId("cell", request.CellId);
            var requestorId = ParseRecordId("user", request.RequestorId);

            var result = await session.Query(@$"
                -- Authorization check
                LET $is_authorized = (
                    (SELECT VALUE in FROM leads WHERE out = {cellId}) CONTAINS {requestorId}
                    OR fn::is_authorized({requestorId}, ['Admin', 'Attendance', 'Cells'])
                );

                IF !$is_authorized THEN
                    THROW 'Not authorized to view attendance for this cell';
                END;

                -- Fetch disciples
                LET $disciples = (SELECT VALUE in FROM disciple_in WHERE out = {cellId});

                -- Fetch attendances with automatic missing attendees calculation
                SELECT
                    type::string(id) AS id,
                    date,
                    topic AS notes,
                    (SELECT id, full_name, phone, gender, photo_path FROM user WHERE id IN (SELECT VALUE in FROM attended_to WHERE out = $parent.id)) AS attendees,
                    (SELECT id, full_name, phone, gender, photo_path FROM user WHERE id IN array::difference($disciples, (SELECT VALUE in FROM attended_to WHERE out = $parent.id))) AS missing_attendees
                FROM cell_meeting
                WHERE cell = {cellId}
                ORDER BY date DESC
                LIMIT 40;
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            var attendancesList = result.GetValue<List<CellAttendanceDto>>(3);

            return attendancesList ?? [];
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
