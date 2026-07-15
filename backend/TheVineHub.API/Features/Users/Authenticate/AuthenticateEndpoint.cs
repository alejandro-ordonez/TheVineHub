using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;

namespace TheVineHub.API.Features.Users.Authenticate
{
    public class AuthenticateEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/users/auth", async ([FromBody] AuthenticateCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("Authenticate")
            .WithTags("Users");

            app.MapPost("/api/users/refresh", async ([FromBody] RefreshTokenCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("RefreshToken")
            .WithTags("Users");
        }
    }
}
