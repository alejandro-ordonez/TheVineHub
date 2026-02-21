using JMMinistry.Common.Dtos.Meetings;
using Mediator;

namespace JMMinistry.Application.Features.Meetings.Commands.CreateMeeting
{
    public class CreateMeetingCommand : CreateMeetingDto, ICommand<MeetingDto>
    {
    }
}