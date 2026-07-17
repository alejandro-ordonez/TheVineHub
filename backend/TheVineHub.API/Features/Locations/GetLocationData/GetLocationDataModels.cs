using TheVineHub.API.Features.Locations;
using TheVineHub.API.Common;
using Mediator;

namespace TheVineHub.API.Features.Locations.GetLocationData
{
    public class GetLocationDataQuery : IQuery<IList<CityDto>>
    {
    }
}
