using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.DiscipleJourney.Staff
{
    public class StaffEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/disciplejourney/cycles/{cycleId}/staff").RequireAuthorization();

            group.MapGet("", async (string cycleId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCycleStaffQuery { CycleId = cycleId });
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin")
            .CacheOutput(policyName: CacheTags.CycleData);

            group.MapPost("", async (string cycleId, [FromBody] CreateCycleStaffRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                var result = await mediator.Send(new AddCycleStaffCommand
                {
                    CycleId = cycleId,
                    PersonId = dto.PersonId,
                    Role = dto.Role
                });

                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin");

            group.MapDelete("/{staffId}", async (string cycleId, string staffId, IMediator mediator, IOutputCacheStore cache) =>
            {
                await mediator.Send(new RemoveCycleStaffCommand { CycleId = cycleId, StaffId = staffId });
                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.NoContent();
            })
            .RequireAuthorization("Admin");
        }
    }
}
