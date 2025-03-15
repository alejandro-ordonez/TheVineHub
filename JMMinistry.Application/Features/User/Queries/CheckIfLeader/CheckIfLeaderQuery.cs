using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries.CheckIfLeader
{
    public class CheckIfLeaderQuery: IRequest<bool>
    {
        public required string LeaderId { get; set; }
        public required int CellId { get; set; }
    }
}
