using JMMinistry.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized
{
    public class CellCheckIsAuthorizedQuery: IRequest<bool>
    {
        public required int CellId { get; set; }
        public IList<Roles> AllowedRoles { get; set; } = [];
        public required string RequestorId { get; set; }
    }
}
