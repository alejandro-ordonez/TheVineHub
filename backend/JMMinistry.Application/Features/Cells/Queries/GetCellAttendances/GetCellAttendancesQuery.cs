using JMMinistry.Common.Dtos.Cell;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.GetCellAttendances
{
    public class GetCellAttendancesQuery : IQuery<IList<CellAttendanceDto>>
    {
        public required string RequestorId { get; set; }
        public required string CellId { get; set; }
    }
}
