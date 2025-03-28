using JMMinistry.Common.Dtos.Gained;
using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Gain.Queries.GetGained
{
    public class GetGainedQuery:  IRequest<IList<GainedUser>>
    {
        public required string Requestor { get; set; }
    }
}
