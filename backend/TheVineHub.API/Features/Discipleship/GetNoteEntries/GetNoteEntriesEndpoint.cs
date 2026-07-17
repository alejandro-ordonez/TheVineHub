using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Discipleship.GetNoteEntries
{
    public class GetNoteEntriesEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/discipleship/{discipleId}/notes/{noteId}/entries", async (string discipleId, string noteId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                var query = new GetNoteEntriesQuery
                {
                    RequestorId = requestorId,
                    DiscipleId = discipleId,
                    NoteId = noteId
                };

                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetDiscipleshipNoteEntries")
            .WithTags("Discipleship")
            .RequireAuthorization();
        }
    }
}
