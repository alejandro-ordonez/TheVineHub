using JMMinistry.Common.Dtos.Cell;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Queries.GetCells
{
    public class GetCellsQuery: IRequest<IEnumerable<CellDto>>
    {
        public required string Document { get; set; }
    }
}
