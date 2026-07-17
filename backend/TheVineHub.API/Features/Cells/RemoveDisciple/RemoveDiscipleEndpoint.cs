using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TheVineHub.API.Features.Cells.RemoveDisciple
{
    public class RemoveDiscipleEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/ministry/disciples/{cellId}/{discipleId}", async (string cellId, string discipleId, IMediator mediator) =>
            {
                var command = new RemoveDiscipleCommand { CellId = cellId, Document = discipleId };
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("RemoveDisciple")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
