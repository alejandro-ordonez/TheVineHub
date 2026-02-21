using JMMinistry.Common.Dtos.Gained;
using Mediator;

namespace JMMinistry.Application.Features.Gain.Queries.GetGained
{
    public class GetGainedQuery : IQuery<IList<GainedUser>>
    {
        public required string Requestor { get; set; }
    }
}
