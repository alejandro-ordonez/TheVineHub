using JMMinistry.Common.Dtos.Common;
using Mediator;
using SurrealDb.Net;

namespace JMMinistry.Application.Features.Location.GetLocationData
{
    public class GetLocationDataHandler(ISurrealDbSession session) : IQueryHandler<GetLocationDataQuery, IList<CityDto>>
    {
        public async ValueTask<IList<CityDto>> Handle(GetLocationDataQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                SELECT *, 
                       (SELECT * FROM locality WHERE id IN (SELECT VALUE in FROM <-part_of WHERE out = $parent.id)) AS localities
                FROM city;
            ", cancellationToken);

            var cities = result.GetValue<List<CityDto>>(0);

            return cities ?? new List<CityDto>();
        }
    }
}
