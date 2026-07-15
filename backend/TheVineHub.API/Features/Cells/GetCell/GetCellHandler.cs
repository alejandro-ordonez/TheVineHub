using TheVineHub.API.Features.Cells;
using TheVineHub.API.Features.Cells.AddDisciples;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;


namespace TheVineHub.API.Features.Cells.GetCell
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

            var cell = result.GetValue<CellDto>(0) ?? throw new Exception("Unexpected null from DB");

            return cell ?? throw new NotFoundException("Cell not found");
        }
    }
}
