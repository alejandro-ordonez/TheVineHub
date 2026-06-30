using JMMinistry.Application.Features.Meetings.Dtos;
using JMMinistry.Application.Features.Meetings.Commands.CreateMeeting;
using Mediator;
using SurrealDb.Net;

using System.Linq;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
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
