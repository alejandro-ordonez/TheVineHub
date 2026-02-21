using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Gained;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Gain.Queries.GetGained
{
    public class GetGainedHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetGainedQuery, IList<GainedUser>>
    {
        public async ValueTask<IList<GainedUser>> Handle(GetGainedQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.PersonalInfo
                .Include(user => user.Gained)
                    .ThenInclude(gained => gained.Events)
                .Include(user => user.Gained)
                    .ThenInclude(gained => gained.Person)
                .FirstOrDefaultAsync(user => user.Id == request.Requestor, cancellationToken) ??
                throw new NotFoundException("User not found");

            return mapper.GainedListToGainedUserList(user.Gained);
        }
    }
}
