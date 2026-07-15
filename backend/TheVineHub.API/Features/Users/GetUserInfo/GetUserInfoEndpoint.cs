using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Users.GetUserInfo
{
    public class GetUserInfoEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users/{document?}", async (string? document, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim();
                if (string.IsNullOrEmpty(requestorId))
                    throw new ArgumentException("Your token must be included");

                var result = await mediator.Send(new GetUserInfoQuery(document ?? requestorId, requestorId));
                return Results.Ok(result);
            })
            .WithName("GetUserInfo")
            .WithTags("Users")
            .RequireAuthorization();
        }
    }
}
