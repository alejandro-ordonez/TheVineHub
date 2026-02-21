using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Meetings;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
{
    public class GetMeetingsHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetMeetingsQuery, IList<MeetingDto>>
    {
        public async ValueTask<IList<MeetingDto>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            var meetings = await dbContext.Meetings
                .ToListAsync(cancellationToken);

            return mapper.MeetingListToMeetingDtoList(meetings);
        }
    }
}
