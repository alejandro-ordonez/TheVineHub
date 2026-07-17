using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Cells.GetCellAttendances
{
    public class GetCellAttendancesEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/ministry/attendances/{cellId}", async (string cellId, HttpContext httpContext, IMediator mediator) =>
            {
                var document = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var query = new GetCellAttendancesQuery { CellId = cellId, RequestorId = document };
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetCellAttendances")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
