using TheVineHub.API.Features.Cells;
using Mediator;

namespace TheVineHub.API.Features.Cells.GetCellAttendances
{
    public sealed class GetCellAttendancesQuery : IQuery<IList<CellAttendanceDto>>
    {
        public required string RequestorId { get; init; }
        public required string CellId { get; init; }
    }
}
