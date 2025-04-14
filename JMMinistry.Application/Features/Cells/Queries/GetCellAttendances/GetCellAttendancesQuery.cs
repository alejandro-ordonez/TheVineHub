using JMMinistry.Common.Dtos.Cell;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Queries.GetCellAttendances
{
    public class GetCellAttendancesQuery: IRequest<IList<CellAttendanceDto>>
    {
        public required string RequestorId { get; set; }
        public required int CellId { get; set; }
    }
}
