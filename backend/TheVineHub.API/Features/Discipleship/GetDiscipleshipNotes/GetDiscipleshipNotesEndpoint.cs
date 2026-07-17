using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Discipleship.GetDiscipleshipNotes
{
    public class GetDiscipleshipNotesEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/discipleship/{discipleId}/notes", async (string discipleId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var query = new GetDiscipleshipNotesQuery
                {
                    RequestorId = requestorId,
                    DiscipleId = discipleId
                };

                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetDiscipleshipNotes")
            .WithTags("Discipleship")
            .RequireAuthorization();
        }
    }
}
