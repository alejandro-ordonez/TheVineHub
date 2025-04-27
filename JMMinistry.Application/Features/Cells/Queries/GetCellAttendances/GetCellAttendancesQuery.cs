using JMMinistry.Common.Dtos.Cell;
using MediatR;

namespace JMMinistry.Application.Features.Cells.Queries.GetCellAttendances
{
    public class GetCellAttendancesQuery : IRequest<IList<CellAttendanceDto>>
    {
        public required string RequestorId { get; set; }
        public required int CellId { get; set; }
    }
}
