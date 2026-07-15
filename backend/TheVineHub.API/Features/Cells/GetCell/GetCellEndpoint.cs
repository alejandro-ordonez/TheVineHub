using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Cells.GetCell
{
    public class GetCellEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/ministry/{cellId}", async (string cellId, HttpContext httpContext, IMediator mediator) =>
            {
                var document = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var query = new GetCellQuery { RequestorId = document, CellId = cellId };
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetCell")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
