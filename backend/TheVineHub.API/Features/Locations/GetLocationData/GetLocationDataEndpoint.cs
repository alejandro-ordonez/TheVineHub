using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.OutputCaching;

namespace TheVineHub.API.Features.Locations.GetLocationData
{
    public class GetLocationDataEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/location", async (IMediator mediator) =>
            {
                var query = new GetLocationDataQuery();
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetLocationData")
            .WithTags("Locations")
            .CacheOutput(policy => policy.Expire(TimeSpan.FromDays(1)));
        }
    }
}
