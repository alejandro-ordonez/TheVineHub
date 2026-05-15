using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Cells.Commands.UpdateAttendance
{
    public class UpdateAttendanceHandler(ISurrealDbSession session) : ICommandHandler<UpdateAttendanceCommand, CellAttendanceDto?>
    {
        public async ValueTask<CellAttendanceDto?> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var cellId = request.CellId.StartsWith("cell:") ? request.CellId : $"cell:{request.CellId}";
            var requestorId = request.RequestorId.StartsWith("user:") ? request.RequestorId : $"user:{request.RequestorId}";
            var attendanceId = request.AttendanceId.StartsWith("cell_meeting:") ? request.AttendanceId : $"cell_meeting:{request.AttendanceId}";

            var result = await session.Query(@$"
                -- Authorization check
                LET $is_authorized = (
                    fn::is_leader(type::thing('user', {requestorId}), type::thing('cell', {cellId}))
                    OR (SELECT VALUE out.name FROM type::thing('user', {requestorId})->member_of WHERE name INSIDE ['Admin', 'Attendance', 'Cells'])[0] != NONE
                );

                IF !$is_authorized THEN
                    THROW 'Not authorized to update attendance for this cell';
                END;

                -- Verify disciples belong to cell
                LET $disciples = (SELECT VALUE in FROM disciple_in WHERE out = type::thing('cell', {cellId}));
                FOR $attendeId IN {request.Attendees} {{
                    IF type::thing('user', $attendeId) NOT INSIDE $disciples THEN
                        THROW 'User ' + $attendeId + ' is not a disciple of this cell';
                    END;
                }};

                BEGIN TRANSACTION;

                -- Update attendance record
                UPDATE type::thing('cell_meeting', {attendanceId}) SET date = {request.Date}, topic = {request.Notes};

                -- Update attendees (Delete old, relate new)
                DELETE attended_to WHERE out = type::thing('cell_meeting', {attendanceId});

                FOR $attendeId IN {request.Attendees} {{
                    RELATE type::thing('user', $attendeId)->attended_to->type::thing('cell_meeting', {attendanceId});
                }};

                COMMIT TRANSACTION;

                RETURN {{
                    id: type::thing('cell_meeting', {attendanceId}),
                    date: {request.Date},
                    notes: {request.Notes},
                    attendees: (SELECT * FROM user WHERE id IN {request.Attendees}),
                    missing_attendees: (SELECT * FROM user WHERE id IN $disciples AND id NOT IN {request.Attendees})
                }};
            ", cancellationToken);

            return result.GetValue<CellAttendanceDto>(0);
        }
    }
}
