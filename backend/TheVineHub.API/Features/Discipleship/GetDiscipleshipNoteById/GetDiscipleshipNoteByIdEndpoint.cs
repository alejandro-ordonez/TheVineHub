using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Discipleship.GetDiscipleshipNoteById
{
    public class GetDiscipleshipNoteByIdEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/discipleship/{discipleId}/notes/{noteId}", async (string discipleId, string noteId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                var query = new GetDiscipleshipNoteByIdQuery
                {
                    RequestorId = requestorId,
                    DiscipleId = discipleId,
                    NoteId = noteId
                };

                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetDiscipleshipNoteById")
            .WithTags("Discipleship")
            .RequireAuthorization();
        }
    }
}
