using JMMinistry.Application.Features.Location.Dtos;
using JMMinistry.Application.Common;
using Mediator;

namespace JMMinistry.Application.Features.Location.GetLocationData
{
    public class GetLocationDataQuery : IQuery<IList<CityDto>>
    {
    }
}
