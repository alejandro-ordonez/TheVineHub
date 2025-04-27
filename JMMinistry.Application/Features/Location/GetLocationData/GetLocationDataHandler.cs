using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Location.GetLocationData
{
    public class GetLocationDataHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetLocationDataQuery, IList<CityDto>>
    {
        public async Task<IList<CityDto>> Handle(GetLocationDataQuery request, CancellationToken cancellationToken)
        {
            var cities = await dbContext.Cities
                .Include(city => city.Localities)
                .ToListAsync(cancellationToken);

            return mapper.Map<IList<CityDto>>(cities);
        }
    }
}
