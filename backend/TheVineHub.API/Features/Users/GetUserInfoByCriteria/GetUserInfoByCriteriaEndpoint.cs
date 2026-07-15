using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using TheVineHub.API.Common;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.Users.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/users/search", async ([FromBody] GetUserInfoByCriteriaQuery criteria, IMediator mediator) =>
            {
                var result = await mediator.Send(criteria);
                return Results.Ok(result);
            })
            .WithName("SearchUsers")
            .WithTags("Users")
            .RequireAuthorization();
        }
    }
}
