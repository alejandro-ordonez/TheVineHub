using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Discipleship.CreateNoteEntry
{
    public class CreateNoteEntryEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/discipleship/{discipleId}/notes/{noteId}/entries", async (string discipleId, string noteId, [FromBody] CreateNoteEntryRequest request, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                var command = new CreateNoteEntryCommand
                {
                    RequestorId = requestorId,
                    DiscipleId = discipleId,
                    NoteId = noteId,
                    Content = request.Content,
                    Date = request.Date
                };

                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("CreateDiscipleshipNoteEntry")
            .WithTags("Discipleship")
            .RequireAuthorization();
        }
    }
}
