using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Queries.GetCells
{
    public class GetCellsHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetCellsCommand, IEnumerable<CellDto>>
    {
        public async Task<IEnumerable<CellDto>> Handle(GetCellsCommand request, CancellationToken cancellationToken)
        {
            var cells = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .Where(cell => cell.Leaders.Any(leader => leader.Id == request.Document))
                .ToListAsync(cancellationToken) ?? [];

            var dtos = mapper.Map<IEnumerable<CellDto>>(cells);

            return dtos;
        }
    }
}
