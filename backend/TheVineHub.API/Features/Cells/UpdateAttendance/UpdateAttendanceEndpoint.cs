using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Cells.UpdateAttendance
{
    public class UpdateAttendanceEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/ministry/attendances/{cellId}/{attendanceId}", async (string cellId, string attendanceId, [FromBody] UpdateAttendanceRequest request, HttpContext httpContext, IMediator mediator) =>
            {
                var document = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                var command = new UpdateAttendanceCommand
                {
                    CellId = cellId,
                    AttendanceId = attendanceId,
                    RequestorId = document,
                    Attendees = request.Disciples,
                    Notes = request.Notes,
                    Date = request.Date
                };

                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateCellAttendance")
            .WithTags("Cells")
            .RequireAuthorization();
        }
    }
}
