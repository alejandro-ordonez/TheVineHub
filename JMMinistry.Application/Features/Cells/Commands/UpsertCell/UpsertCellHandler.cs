using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell;

public class UpsertCellHandler(IJmDbContext dbContext, AppMapper mapper) :
    ICommandHandler<UpsertCellCommand, CellDto>
{
    public async ValueTask<CellDto> Handle(UpsertCellCommand request, CancellationToken cancellationToken)
    {
        var model = mapper.CellDtoToCell(request);

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

        var dto = mapper.CellToCellDto(model);
        return dto;
    }
}
