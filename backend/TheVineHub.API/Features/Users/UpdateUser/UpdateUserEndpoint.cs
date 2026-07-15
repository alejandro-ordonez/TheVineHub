using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.Users.UpdateUser
{
    public class UpdateUserEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/users", async ([FromBody] UpdateUserCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateUser")
            .WithTags("Users")
            .RequireAuthorization();
        }
    }
}
