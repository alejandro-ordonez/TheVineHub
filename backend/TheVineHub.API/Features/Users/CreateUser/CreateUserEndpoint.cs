using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TheVineHub.API.Common;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Users.CreateUser
{
    public class CreateUserEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/users/register", async ([FromBody] CreateUserCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Text(result, MediaTypeNames.Text.Plain, statusCode: StatusCodes.Status201Created);
            })
            .WithName("RegisterUser")
            .WithTags("Users");
        }
    }
}
