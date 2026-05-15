using JMMinistry.Application.Exceptions;
using JMMinistry.Common.Dtos.Cell;
using Mediator;
using SurrealDb.Net;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell;

public class UpsertCellHandler(ISurrealDbSession session) :
    ICommandHandler<UpsertCellCommand, CellDto>
{
    public async ValueTask<CellDto> Handle(UpsertCellCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id))
        {
            // Create new cell and relate to leader
            var result = await session.Query(@$"
                BEGIN TRANSACTION;
                
                LET $cell = (CREATE cell SET 
                    name = {request.Name}, 
                    description = {request.Description}, 
                    main_cell = {request.MainCell}, 
                    address = {request.Address}, 
                    day = {request.Day?.ToString()}, 
                    opening_date = {request.OpeningDate?.ToDateTime(TimeOnly.MinValue)})[0];
                
                RELATE type::thing('user', {request.Document})->leads->$cell.id SET since = time::now();
                
                COMMIT TRANSACTION;
                
                RETURN $cell;
            ", cancellationToken);

            return result.GetValue<CellDto>(0);
        }
        else
        {
            // Update existing cell
            var result = await session.Query(@$"
                UPDATE type::thing('cell', {request.Id}) SET 
                    name = {request.Name}, 
                    description = {request.Description}, 
                    main_cell = {request.MainCell}, 
                    address = {request.Address}, 
                    day = {request.Day?.ToString()}, 
                    opening_date = {request.OpeningDate?.ToDateTime(TimeOnly.MinValue)}
                RETURN AFTER;
            ", cancellationToken);

            return result.GetValue<CellDto>(0);
        }
    }
}
