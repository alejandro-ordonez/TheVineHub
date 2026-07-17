using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Users.MarryLeaders
{
    public class MarryLeadersEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/users/marry", async ([FromBody] MarryLeadersRequest request, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

                await mediator.Send(new MarryLeadersCommand
                {
                    RequestorId = requestorId,
                    PersonId = request.PersonId,
                    SpouseId = request.SpouseId
                });

                return Results.Ok(new { });
            })
            .WithName("MarryLeaders")
            .WithTags("Users")
            .RequireAuthorization();
        }
    }
}
