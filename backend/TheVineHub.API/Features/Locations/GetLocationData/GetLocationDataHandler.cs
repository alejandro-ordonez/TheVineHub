using TheVineHub.API.Features.Locations;
using TheVineHub.API.Common;
using Mediator;
using SurrealDb.Net;

namespace TheVineHub.API.Features.Locations.GetLocationData
{
    public class GetLocationDataHandler(ISurrealDbSession session) : IQueryHandler<GetLocationDataQuery, IList<CityDto>>
    {
        public async ValueTask<IList<CityDto>> Handle(GetLocationDataQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                SELECT 
                    type::string(id) AS id,
                    name,
                    (SELECT type::string(in) AS id, in.name AS name FROM part_of WHERE out = $parent.id) AS localities
                FROM city;
            ", cancellationToken);

            var cities = result.GetValue<List<CityDto>>(0);

            return cities ?? new List<CityDto>();
        }
    }
}
