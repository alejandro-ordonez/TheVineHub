using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.DiscipleJourney.Sessions
{
    public class SessionsEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/disciplejourney/cycles/{cycleId}/sessions").RequireAuthorization();

            group.MapGet("", async (string cycleId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCycleSessionsQuery { CycleId = cycleId });
                return Results.Ok(result);
            })
            .CacheOutput(policyName: CacheTags.CycleData);

            group.MapPost("", async (string cycleId, [FromBody] CreateCycleSessionRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                var result = await mediator.Send(new CreateCycleSessionCommand
                {
                    CycleId = cycleId,
                    Date = dto.Date,
                    Topic = dto.Topic
                });

                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin");

            group.MapDelete("/{sessionId}", async (string cycleId, string sessionId, IMediator mediator, IOutputCacheStore cache) =>
            {
                await mediator.Send(new DeleteCycleSessionCommand { CycleId = cycleId, SessionId = sessionId });
                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.NoContent();
            })
            .RequireAuthorization("Admin");
        }
    }
}
