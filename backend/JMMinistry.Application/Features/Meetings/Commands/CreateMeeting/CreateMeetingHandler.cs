using JMMinistry.Common.Dtos.Meetings;
using Mediator;
using SurrealDb.Net;

namespace JMMinistry.Application.Features.Meetings.Commands.CreateMeeting
{
    public class CreateMeetingHandler(ISurrealDbSession session) : ICommandHandler<CreateMeetingCommand, MeetingDto>
    {
        public async ValueTask<MeetingDto> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                CREATE meeting SET 
                    name = {request.Name}, 
                    start = {request.Start.ToString()}, 
                    end = {request.End.ToString()}, 
                    meeting_type = {request.MeetingTypes.ToString()}, 
                    is_recurrent = {request.IsRecurrent}, 
                    day_of_week = {request.DayOfWeek?.ToString()}, 
                    date = {request.Date.ToDateTime(TimeOnly.MinValue)}
                RETURN AFTER;
            ", cancellationToken);

            return result.GetValue<MeetingDto>(0);
        }
    }
}
