using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Hierarchy.IsLeaderInHierarchy
{
    public class IsLeaderInHierarchyEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users/{discipleId}/is-leader", async (string discipleId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var query = new IsLeaderInHierarchyQuery
                {
                    RequestorId = requestorId,
                    DiscipleId = discipleId
                };

                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("IsLeaderInHierarchy")
            .WithTags("Users")
            .RequireAuthorization();
        }
    }
}
