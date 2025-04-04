using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Meetings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Meetings.Queries.GetMeetings
{
    public class GetMeetingsHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetMeetingsQuery, IList<MeetingDto>>
    {
        public async Task<IList<MeetingDto>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            var meetings = await dbContext.Meetings
                .ToListAsync(cancellationToken);

            return mapper.Map<IList<MeetingDto>>(meetings);
        }
    }
}
