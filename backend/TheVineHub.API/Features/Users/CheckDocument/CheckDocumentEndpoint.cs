using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.Users.CheckDocument
{
    public class CheckDocumentEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users/check/{document}", async (string document, IMediator mediator) =>
            {
                var result = await mediator.Send(new CheckDocumentExistsQuery { Document = document });
                return Results.Ok(result);
            })
            .WithName("CheckDocumentExists")
            .WithTags("Users")
            .RequireAuthorization();
        }
    }
}
