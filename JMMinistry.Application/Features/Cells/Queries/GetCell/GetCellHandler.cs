using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.GetCell
{
    public class GetCellHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetCellQuery, CellDto>
    {
        public async ValueTask<CellDto> Handle(GetCellQuery request, CancellationToken cancellationToken)
        {
            var cell = await dbContext.Cells
                .Include(cell => cell.Leaders)
                .Include(cell => cell.City)
                .Include(cell => cell.Locality)
                .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken);

            return mapper.CellToCellDto(cell);
        }
    }
}
