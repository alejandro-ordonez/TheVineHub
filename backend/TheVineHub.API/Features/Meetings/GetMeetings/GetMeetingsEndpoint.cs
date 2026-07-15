using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.Meetings.GetMeetings
{
    public class GetMeetingsEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/meetings", async (IMediator mediator) =>
            {
                var query = new GetMeetingsQuery();
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetMeetings")
            .WithTags("Meetings")
            .CacheOutput(policyName: CacheTags.Meetings)
            .RequireAuthorization();
        }
    }
}
