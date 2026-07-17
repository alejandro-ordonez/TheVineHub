using TheVineHub.API.Features.Cells;
using TheVineHub.API.Features.Cells.AddDisciples;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Cells.RecordAttendance
{
    public class RecordAttendanceHandler(ISurrealDbSession session) : ICommandHandler<RecordAttendanceCommand, CellAttendanceDto?>
    {
        public async ValueTask<CellAttendanceDto?> Handle(RecordAttendanceCommand request, CancellationToken cancellationToken)
        {
            var cellId = ParseRecordId("cell", request.CellId);
            var requestorId = ParseRecordId("user", request.RequestorId);
            var attendeeIds = request.Attendees.Select(a => ParseRecordId("user", a)).ToList();

            var result = await session.Query(@$"
                {{
                    -- Authorization check
                    LET $is_authorized = (
                        (SELECT VALUE in FROM leads WHERE out = {cellId}) CONTAINS {requestorId}
                        OR (SELECT VALUE out.name FROM {requestorId}->member_of WHERE name INSIDE ['Admin', 'Attendance', 'Cells'])[0] != NONE
                    );

                    IF !$is_authorized THEN
                        THROW 'Not authorized to record attendance for this cell';
                    END;

                    -- Verify disciples belong to cell
                    LET $disciples = (SELECT VALUE in FROM disciple_in WHERE out = {cellId});
                    FOR $attendeId IN {attendeeIds} {{
                        IF $attendeId NOT IN $disciples THEN
                            THROW 'User ' + type::string($attendeId) + ' is not a disciple of this cell';
                        END;
                    }};

                    -- Create attendance record
                    LET $attendance = (CREATE cell_meeting SET date = time::now(), topic = {request.Notes}, cell = {cellId})[0];

                    -- Relate attendees
                    FOR $attendeId IN {attendeeIds} {{
                        RELATE $attendeId->attended_to->$attendance;
                    }};

                    RETURN {{
                        id: type::string($attendance.id),
                        date: $attendance.date,
                        notes: $attendance.topic,
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
