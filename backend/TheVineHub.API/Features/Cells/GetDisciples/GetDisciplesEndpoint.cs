using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Cells.GetDisciples
{
    public class GetDisciplesEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/ministry/disciples/{cellId}", async (string cellId, HttpContext httpContext, IMediator mediator) =>
            {
                var document = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                var query = new GetDisciplesQuery
                {
                    CellId = cellId,
                    RequestorId = document
                };

                var response = await mediator.Send(query);
                return Results.Ok(response);
            })
            .WithName("GetDisciples")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
