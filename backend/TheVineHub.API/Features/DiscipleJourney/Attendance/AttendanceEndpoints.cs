using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.DiscipleJourney.Attendance
{
    public class AttendanceEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/disciplejourney/cycles/{cycleId}/attendance", async (string cycleId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCycleAttendanceQuery { CycleId = cycleId });
                return Results.Ok(result);
            })
            .RequireAuthorization()
            .CacheOutput(policyName: CacheTags.CycleData);

            app.MapPost("/api/disciplejourney/cycles/{cycleId}/sessions/{sessionId}/attendance", async (string cycleId, string sessionId, [FromBody] RecordCycleAttendanceRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                await mediator.Send(new RecordCycleAttendanceCommand
                {
                    CycleId = cycleId,
                    SessionId = sessionId,
                    DiscipleIds = dto.DiscipleIds
                });

                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.NoContent();
            })
            .RequireAuthorization();
        }
    }
}
