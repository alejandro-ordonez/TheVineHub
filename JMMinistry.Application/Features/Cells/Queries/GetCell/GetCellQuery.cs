using JMMinistry.Common.Dtos.Cell;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.GetCell
{
    public class GetCellQuery : IQuery<CellDto>
    {
        public required string RequestorId { get; set; }
        public int CellId { get; set; }
    }
}
