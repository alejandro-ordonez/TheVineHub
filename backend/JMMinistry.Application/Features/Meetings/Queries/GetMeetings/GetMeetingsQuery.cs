using JMMinistry.Common.Dtos.Meetings;
using Mediator;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
{
    public class GetMeetingsQuery : IQuery<IList<MeetingDto>>
    {
        public bool IsRecurrent { get; set; }
    }
}
