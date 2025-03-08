using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesQuery: PagedRequest, IRequest<PagedResponse<UserInfoDto>>
    {
        public required int CellId { get; set; }
        public required string DocumentLeader { get; set; }
    }
}
