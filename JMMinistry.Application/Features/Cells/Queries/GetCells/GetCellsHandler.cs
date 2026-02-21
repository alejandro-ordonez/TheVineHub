using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.GetCells
{
    public class GetCellsHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetCellsQuery, IEnumerable<CellDto>>
    {
        public async ValueTask<IEnumerable<CellDto>> Handle(GetCellsQuery request, CancellationToken cancellationToken)
        {
            var cells = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .Where(cell => cell.Leaders.Any(leader => leader.Id == request.Document))
                .ToListAsync(cancellationToken) ?? [];

            var dtos = mapper.CellListToCellDtoList(cells);

            return dtos;
        }
    }
}
