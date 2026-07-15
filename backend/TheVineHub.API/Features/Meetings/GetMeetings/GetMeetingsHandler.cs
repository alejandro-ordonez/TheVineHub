using TheVineHub.API.Features.Meetings;
using TheVineHub.API.Features.Meetings.CreateMeeting;
using Mediator;
using SurrealDb.Net;

using System.Linq;

namespace TheVineHub.API.Features.Meetings.GetMeetings
{
    public class GetMeetingsHandler(ISurrealDbSession session) : IQueryHandler<GetMeetingsQuery, IList<MeetingDto>>
    {
        public async ValueTask<IList<MeetingDto>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query($@"
                SELECT 
                    type::string(id) AS meeting_id,
                    name,
                    start,
                    end,
                    meeting_type,
                    is_recurrent,
                    day_of_week,
                    date
                FROM church_meeting;
            ", cancellationToken);

            var meetings = result.GetValue<List<MeetingDto>>(0);

            return meetings ?? new List<MeetingDto>();
        }
    }
}
