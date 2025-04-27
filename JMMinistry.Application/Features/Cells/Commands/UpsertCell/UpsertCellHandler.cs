using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell;

public class UpsertCellHandler(IJmDbContext dbContext, IMapper mapper) :
    IRequestHandler<UpsertCellCommand, CellDto>
{
    public async Task<CellDto> Handle(UpsertCellCommand request, CancellationToken cancellationToken)
    {
        var model = mapper.Map<Cell>(request);

        if (request.Id is not null && await dbContext.Cells.AnyAsync(cell => cell.Id == request.Id, cancellationToken))
            throw new EntityAlreadyExistsException<Cell>();

        var user = await dbContext.PersonalInfo.FirstOrDefaultAsync(user => user.Id == request.Document, cancellationToken) ??
            throw new NotFoundException(request.Document);

        if (request.Id is null)
        {
            user.Cells.Add(model);
            dbContext.PersonalInfo.Update(user);
        }

        else
            dbContext.Cells.Update(model);

        await dbContext.SaveChangesAsync(cancellationToken);

        var dto = mapper.Map<CellDto>(model);
        return dto;
    }
}
