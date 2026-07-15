using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;

namespace TheVineHub.API.Features.Cells.AddDisciples
{
    public class AddDisciplesEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/ministry/disciples/{cellId}", async (string cellId, [FromBody] AddDisciplesRequest request, IMediator mediator) =>
            {
                var command = new AddDisciplesCommand
                {
                    CellId = cellId,
                    Documents = request.Documents
                };
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("AddDisciples")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
