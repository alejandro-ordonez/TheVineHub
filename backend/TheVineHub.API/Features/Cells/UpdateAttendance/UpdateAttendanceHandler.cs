using TheVineHub.API.Features.Cells;
using TheVineHub.API.Features.Cells.AddDisciples;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Cells.UpdateAttendance
{
    public class UpdateAttendanceHandler(ISurrealDbSession session) : ICommandHandler<UpdateAttendanceCommand, CellAttendanceDto?>
    {
        public async ValueTask<CellAttendanceDto?> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var cellId = ParseRecordId("cell", request.CellId);
            var requestorId = ParseRecordId("user", request.RequestorId);
            var attendanceId = ParseRecordId("cell_meeting", request.AttendanceId);
            var attendeeIds = request.Attendees.Select(a => ParseRecordId("user", a)).ToList();

            var result = await session.Query(@$"
                {{
                    -- Authorization check
                    LET $is_authorized = (
                        (SELECT VALUE in FROM leads WHERE out = {cellId}) CONTAINS {requestorId}
                        OR (SELECT VALUE out.name FROM {requestorId}->member_of WHERE name INSIDE ['Admin', 'Attendance', 'Cells'])[0] != NONE
                    );

                    IF !$is_authorized THEN
                        THROW 'Not authorized to update attendance for this cell';
                    END;

                    -- Verify disciples belong to cell
                    LET $disciples = (SELECT VALUE in FROM disciple_in WHERE out = {cellId});
                    FOR $attendeId IN {attendeeIds} {{
                        IF $attendeId NOT IN $disciples THEN
                            THROW 'User ' + type::string($attendeId) + ' is not a disciple of this cell';
                        END;
                    }};

                    -- Update attendance record
                    UPDATE {attendanceId} SET date = {request.Date}, topic = {request.Notes};

                    -- Update attendees (Delete old, relate new)
                    DELETE attended_to WHERE out = {attendanceId};

                    FOR $attendeId IN {attendeeIds} {{
                        RELATE $attendeId->attended_to->{attendanceId};
                    }};

                    RETURN {{
                        id: type::string({attendanceId}),
                        date: {request.Date},
                        notes: {request.Notes},
                        attendees: (SELECT * FROM user WHERE id IN {attendeeIds}),
                        missing_attendees: (SELECT * FROM user WHERE id IN $disciples AND id NOT IN {attendeeIds})
                    }};
                }}
            ", cancellationToken);

            return result.GetValue<CellAttendanceDto>(0) ?? throw new Exception("Unexpected null from DB");
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
