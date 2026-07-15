using TheVineHub.API.Features.Meetings;
using TheVineHub.API.Features.Meetings.CreateMeeting;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;

namespace TheVineHub.API.Features.Meetings.CreateMeeting
{
    public class CreateMeetingHandler(ISurrealDbSession session) : ICommandHandler<CreateMeetingCommand, MeetingDto>
    {
        public async ValueTask<MeetingDto> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                {{
                    LET $meeting = (CREATE church_meeting SET 
                        name = {request.Name}, 
                        start = {request.Start}, 
                        end = {request.End}, 
                        meeting_type = {request.MeetingType.ToString()}, 
                        is_recurrent = {request.IsRecurrent}, 
                        day_of_week = {request.DayOfWeek?.ToString()} OR NONE, 
                        date = {request.Date.ToDateTime(TimeOnly.MinValue)})[0];

                    RETURN {{
                        meeting_id: type::string($meeting.id),
                        name: $meeting.name,
                        start: $meeting.start,
                        end: $meeting.end,
                        meeting_type: $meeting.meeting_type,
                        is_recurrent: $meeting.is_recurrent,
                        day_of_week: $meeting.day_of_week,
                        date: $meeting.date
                    }};
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new Exception($"SurrealDB Error: {errorRes.Details}");

                throw new Exception($"SurrealDB Error: {error}");
            }

            return result.GetValue<MeetingDto>(0) ?? throw new Exception("Unexpected null from DB");
        }
    }
}
