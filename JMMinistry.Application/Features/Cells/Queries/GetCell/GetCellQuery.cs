using JMMinistry.Common.Dtos.Cell;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Queries.GetCell
{
    public class GetCellQuery: IRequest<CellDto>
    {
        public required string RequestorId { get; set; }
        public int CellId { get; set; }
    }
}
