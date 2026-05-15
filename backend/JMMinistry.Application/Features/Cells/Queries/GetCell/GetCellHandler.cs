using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;
using JMMinistry.Domain.Cells;

namespace JMMinistry.Application.Features.Cells.Queries.GetCell
{
    public class GetCellHandler(ISurrealDbSession session) : IQueryHandler<GetCellQuery, CellDto>
    {
        public async ValueTask<CellDto> Handle(GetCellQuery request, CancellationToken cancellationToken)
        {
            var cellId = request.CellId.StartsWith("cell:") ? request.CellId : $"cell:{request.CellId}";

            var result = await session.Query(@$"
                SELECT 
                    *, 
                    -- Traverses back to the users who lead this cell and expands their records
                    <-leads.in.*.{{id, full_name, photo_path}} AS leaders 
                FROM ONLY type::record('cell', {request.CellId});
            ", cancellationToken);

            var cell = result.GetValue<Cell>(0);

            return cell?.ToDto() ?? throw new NotFoundException("Cell not found");
        }
    }
}
