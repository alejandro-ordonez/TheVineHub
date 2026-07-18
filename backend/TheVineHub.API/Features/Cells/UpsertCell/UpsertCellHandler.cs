using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.Cells;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Cells.UpsertCell;

public class UpsertCellHandler(ISurrealDbSession session) :
    ICommandHandler<UpsertCellCommand, CellDto>
{
    public async ValueTask<CellDto> Handle(UpsertCellCommand request, CancellationToken cancellationToken)
    {
        string? dayStr = request.Day?.ToString();
        var leaderId = RecordId.From("user", request.Document);

        if (request.Id == null)
        {
            // Create new cell and relate to leader
            var result = await session.Query(@$"
                {{
                    LET $cell = (CREATE cell SET
                        name = {request.Name},
                        description = {request.Description} OR NONE,
                        main_cell = {request.MainCell},
                        address = {request.Address},
                        day = {dayStr} OR NONE,
                        opening_date = {request.OpeningDate?.ToDateTime(TimeOnly.MinValue)} OR NONE)[0];

                    RELATE {leaderId}->leads->$cell SET since = time::now();

                    RETURN $cell;
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            return result.GetValue<CellDto>(0) ?? throw new Exception("Unexpected null from DB");
        }
        else
        {
            // Update existing cell
            var result = await session.Query(@$"
                UPDATE {request.Id} SET
                    name = {request.Name},
                    description = {request.Description} OR NONE,
                    main_cell = {request.MainCell},
                    address = {request.Address},
                    day = {dayStr} OR NONE,
                    opening_date = {request.OpeningDate?.ToDateTime(TimeOnly.MinValue)} OR NONE
                RETURN AFTER;
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            return result.GetValue<CellDto>(0) ?? throw new Exception("Unexpected null from DB");
        }
    }
}
