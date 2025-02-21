using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell;

public class CreateCellHandler (IJmDbContext dbContext, IMapper mapper) : 
    IRequestHandler<CreateCellCommand, CellDto>
{
    public async Task<CellDto> Handle(CreateCellCommand request, CancellationToken cancellationToken)
    {
        var model = mapper.Map<Cell>(request);

        if (await dbContext.Cells.AnyAsync(cell => cell.Name == request.Name, cancellationToken))
            throw new EntityAlreadyExistsException<Cell>();

        var user = await dbContext.PersonalInfo.FirstOrDefaultAsync(user => user.Id == request.Document, cancellationToken) ??
            throw new NotFoundException(request.Document);

        user.Cells.Add(model);

        dbContext.PersonalInfo.Update(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        var dto = mapper.Map<CellDto>(model);
        return dto;
    }
}
