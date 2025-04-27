using JMMinistry.Common.Dtos.Cell;
using MediatR;

namespace JMMinistry.Application.Features.Cells.Queries.GetCells
{
    public class GetCellsQuery : IRequest<IEnumerable<CellDto>>
    {
        public required string Document { get; set; }
    }
}
