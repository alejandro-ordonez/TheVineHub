using JMMinistry.Application.Features.Meetings.Dtos;
using JMMinistry.Application.Features.Meetings.Commands.CreateMeeting;
using Mediator;

namespace JMMinistry.Application.Features.Meetings.Commands.CreateMeeting
{
    public class CreateMeetingCommand : CreateMeetingDto, ICommand<MeetingDto>
    {
    }
}
