using JMMinistry.Common.Dtos.Meetings;
using MediatR;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
{
    public class GetMeetingsQuery : IRequest<IList<MeetingDto>>
    {
        public bool IsRecurrent { get; set; }
    }
}
