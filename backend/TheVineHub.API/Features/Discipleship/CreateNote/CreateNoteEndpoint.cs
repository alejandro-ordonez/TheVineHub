using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Discipleship.CreateNote
{
    public class CreateNoteEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/discipleship/{discipleId}/notes", async (string discipleId, [FromBody] CreateNoteRequest request, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                var command = new CreateNoteCommand
                {
                    RequestorId = requestorId,
                    DiscipleId = discipleId,
                    Title = request.Title,
                    Description = request.Description,
                    Categories = request.Categories
                };

                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("CreateDiscipleshipNote")
            .WithTags("Discipleship")
            .RequireAuthorization();
        }
    }
}
