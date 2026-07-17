using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TheVineHub.API.Features.Cells.UpsertCell
{
    public class UpsertCellEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/cells", async (UpsertCellCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpsertCell")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
