using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples;

public class AddDisciplesHandler(IJmDbContext dbContext, IMapper mapper) : 
    IRequestHandler<AddDisciplesCommand, CellDto>
{
    public async Task<CellDto> Handle(AddDisciplesCommand request, CancellationToken cancellationToken)
    {
        var users = await dbContext.PersonalInfo
            .Where(user => request.Documents.Contains(user.Document))
            .ToListAsync(cancellationToken);

        if (users.Count != request.Documents.Count)
            throw new Exception("There were users that do not exists");

        var cell = await dbContext.Cells
            .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken) ??
            throw new NotFoundException<Cell>(request.CellId.ToString());

        foreach (var disciple in users)
            cell.Disciples.Add(disciple);

        await dbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<CellDto>(cell);
    }
}
