using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Common;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Location.GetLocationData
{
    public class GetLocationDataHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetLocationDataQuery, IList<CityDto>>
    {
        public async ValueTask<IList<CityDto>> Handle(GetLocationDataQuery request, CancellationToken cancellationToken)
        {
            var cities = await dbContext.Cities
                .Include(city => city.Localities)
                .ToListAsync(cancellationToken);

            return mapper.CityListToCityDtoList(cities);
        }
    }
}
