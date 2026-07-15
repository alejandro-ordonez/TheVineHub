using TheVineHub.API.Features.Cells;
using Mediator;

namespace TheVineHub.API.Features.Cells.GetCells
{
    public sealed class GetCellsQuery : IQuery<IEnumerable<CellDto>>
    {
        public required string Document { get; init; }
    }
}
