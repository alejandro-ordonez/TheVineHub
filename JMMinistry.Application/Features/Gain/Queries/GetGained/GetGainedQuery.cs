using JMMinistry.Common.Dtos.Gained;
using MediatR;

namespace JMMinistry.Application.Features.Gain.Queries.GetGained
{
    public class GetGainedQuery : IRequest<IList<GainedUser>>
    {
        public required string Requestor { get; set; }
    }
}
