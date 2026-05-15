using JMMinistry.Common.Dtos.Meetings;
using Mediator;
using SurrealDb.Net;

using System.Linq;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
{
    public class GetMeetingsHandler(ISurrealDbSession session) : IQueryHandler<GetMeetingsQuery, IList<MeetingDto>>
    {
        public async ValueTask<IList<MeetingDto>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query($"SELECT * FROM meeting", cancellationToken);

            var meetings = result.GetValue<List<MeetingDto>>(0);

            return meetings ?? new List<MeetingDto>();
        }
    }
}
