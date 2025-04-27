using JMMinistry.Common.Dtos.Cell;
using MediatR;

namespace JMMinistry.Application.Features.Cells.Queries.GetCell
{
    public class GetCellQuery : IRequest<CellDto>
    {
        public required string RequestorId { get; set; }
        public int CellId { get; set; }
    }
}
