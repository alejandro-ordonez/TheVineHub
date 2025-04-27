using JMMinistry.Common.Dtos.Meetings;
using MediatR;

namespace JMMinistry.Application.Features.Meetings.Commands.CreateMeeting
{
    public class CreateMeetingCommand : CreateMeetingDto, IRequest<MeetingDto>
    {
    }
}