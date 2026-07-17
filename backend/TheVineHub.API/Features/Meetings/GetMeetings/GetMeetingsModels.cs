using TheVineHub.API.Features.Meetings;
using Mediator;

namespace TheVineHub.API.Features.Meetings.GetMeetings
{
    public sealed class GetMeetingsQuery : IQuery<IList<MeetingDto>>
    {
        public bool IsRecurrent { get; init; }
    }
}
