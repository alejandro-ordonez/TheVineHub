using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Cells.GetCells
{
    public class GetCellsEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/ministry", async (HttpContext httpContext, IMediator mediator) =>
            {
                var document = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var query = new GetCellsQuery { Document = document };
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetCells")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
