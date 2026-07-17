using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles
{
    public class CyclesEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var stepsGroup = app.MapGroup("/api/disciplejourney/steps/{stepId}/cycles").RequireAuthorization();
            var cyclesGroup = app.MapGroup("/api/disciplejourney/cycles").RequireAuthorization();

            stepsGroup.MapGet("", async (string stepId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetStepCyclesQuery { StepId = stepId });
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin")
            .CacheOutput(policyName: CacheTags.StepCycles);

            stepsGroup.MapGet("/active", async (string stepId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetActiveCyclesForStepQuery { StepId = stepId });
                return Results.Ok(result);
            })
            .CacheOutput(policyName: CacheTags.StepCycles);

            stepsGroup.MapPost("", async (string stepId, [FromBody] CreateStepCycleRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                var result = await mediator.Send(new CreateStepCycleCommand
                {
                    StepId = stepId,
                    Name = dto.Name,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    MinAttendanceRequired = dto.MinAttendanceRequired,
                    EnrollmentDeadline = dto.EnrollmentDeadline
                });

                await cache.EvictByTagAsync(CacheTags.StepCycles, default);
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin");

            stepsGroup.MapPut("/{cycleId}", async (string stepId, string cycleId, [FromBody] UpdateStepCycleRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                var result = await mediator.Send(new UpdateStepCycleCommand
                {
                    StepId = stepId,
                    CycleId = cycleId,
                    Name = dto.Name,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    MinAttendanceRequired = dto.MinAttendanceRequired,
                    IsOpen = dto.IsOpen,
                    EnrollmentDeadline = dto.EnrollmentDeadline
                });

                await cache.EvictByTagAsync(CacheTags.StepCycles, default);
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin");

            stepsGroup.MapDelete("/{cycleId}", async (string stepId, string cycleId, IMediator mediator, IOutputCacheStore cache) =>
            {
                await mediator.Send(new DeleteStepCycleCommand { StepId = stepId, CycleId = cycleId });
                await cache.EvictByTagAsync(CacheTags.StepCycles, default);
                return Results.NoContent();
            })
            .RequireAuthorization("Admin");

            cyclesGroup.MapGet("/{cycleId}/details", async (string cycleId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCycleDetailsQuery { CycleId = cycleId });
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin")
            .CacheOutput(policyName: CacheTags.CycleData);
        }
    }
}
