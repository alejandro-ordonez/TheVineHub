using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.GetCell
{
    public class GetCellHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetCellQuery, CellDto>
    {
        public async Task<CellDto> Handle(GetCellQuery request, CancellationToken cancellationToken)
        {
            var cell = await dbContext.Cells
                .Include(cell => cell.Leaders)
                .Include(cell => cell.City)
                .Include(cell => cell.Locality)
                .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken);

            return mapper.Map<CellDto>(cell);
        }
    }
}
