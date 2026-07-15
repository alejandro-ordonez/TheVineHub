using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Cells.RecordAttendance
{
    public class RecordAttendanceEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/ministry/attendances/{cellId}", async (string cellId, [FromBody] RecordAttendanceRequest request, HttpContext httpContext, IMediator mediator) =>
            {
                var document = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                var command = new RecordAttendanceCommand
                {
                    CellId = cellId,
                    RequestorId = document,
                    Attendees = request.Disciples,
                    Notes = request.Notes
                };

                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("RecordAttendance")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
