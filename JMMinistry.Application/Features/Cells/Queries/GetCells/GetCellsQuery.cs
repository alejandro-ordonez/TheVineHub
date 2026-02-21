using JMMinistry.Common.Dtos.Cell;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.GetCells
{
    public class GetCellsQuery : IQuery<IEnumerable<CellDto>>
    {
        public required string Document { get; set; }
    }
}
