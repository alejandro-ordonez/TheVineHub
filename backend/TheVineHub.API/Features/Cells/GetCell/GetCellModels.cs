using TheVineHub.API.Features.Cells;
using Mediator;

namespace TheVineHub.API.Features.Cells.GetCell
{
    public sealed class GetCellQuery : IQuery<CellDto>
    {
        public required string RequestorId { get; init; }
        public required string CellId { get; init; }
    }
}
