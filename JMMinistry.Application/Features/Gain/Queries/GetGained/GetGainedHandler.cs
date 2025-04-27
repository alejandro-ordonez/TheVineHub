using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Gained;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Gain.Queries.GetGained
{
    public class GetGainedHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetGainedQuery, IList<GainedUser>>
    {
        public async Task<IList<GainedUser>> Handle(GetGainedQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.PersonalInfo
                .Include(user => user.Gained)
                    .ThenInclude(gained => gained.Events)
                .Include(user => user.Gained)
                    .ThenInclude(gained => gained.Person)
                .FirstOrDefaultAsync(user => user.Id == request.Requestor, cancellationToken) ??
                throw new NotFoundException("User not found");

            return mapper.Map<IList<GainedUser>>(user.Gained);
        }
    }
}
