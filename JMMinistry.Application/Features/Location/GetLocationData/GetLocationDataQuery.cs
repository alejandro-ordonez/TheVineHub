using JMMinistry.Common.Dtos.Common;
using MediatR;

namespace JMMinistry.Application.Features.Location.GetLocationData
{
    public class GetLocationDataQuery : IRequest<IList<CityDto>>
    {
    }
}
