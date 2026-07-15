using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class StepsEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/disciplejourney/steps").RequireAuthorization();

            group.MapGet("", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetDiscipleStepsQuery());
                return Results.Ok(result);
            })
            .CacheOutput(policyName: CacheTags.DiscipleSteps);

            group.MapGet("/{stepId}/disciples", async (string stepId, [FromQuery] string? cellId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var result = await mediator.Send(new GetStepDisciplesQuery
                {
                    RequestorId = requestorId,
                    StepId = stepId,
                    CellId = cellId
                });
                return Results.Ok(result);
            });

            group.MapPost("", async ([FromBody] CreateDiscipleStepRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                var result = await mediator.Send(new CreateDiscipleStepCommand
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    StepCategory = dto.StepCategory,
                    RequiresCycle = dto.RequiresCycle,
                    RequiresAdminApproval = dto.RequiresAdminApproval,
                    RequirementIds = dto.RequirementIds,
                    ParentStepId = dto.ParentStepId
                });

                await cache.EvictByTagAsync(CacheTags.DiscipleSteps, default);
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin");

            group.MapPut("/{stepId}", async (string stepId, [FromBody] UpdateDiscipleStepRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                var result = await mediator.Send(new UpdateDiscipleStepCommand
                {
                    Id = stepId,
                    Name = dto.Name,
                    Description = dto.Description,
                    StepCategory = dto.StepCategory,
                    RequiresCycle = dto.RequiresCycle,
                    RequiresAdminApproval = dto.RequiresAdminApproval,
                    RequirementIds = dto.RequirementIds,
                    ParentStepId = dto.ParentStepId
                });

                await cache.EvictByTagAsync(CacheTags.DiscipleSteps, default);
                return Results.Ok(result);
            })
            .RequireAuthorization("Admin");

            group.MapDelete("/{stepId}", async (string stepId, IMediator mediator, IOutputCacheStore cache) =>
            {
                await mediator.Send(new DeleteDiscipleStepCommand { StepId = stepId });
                await cache.EvictByTagAsync(CacheTags.DiscipleSteps, default);
                return Results.NoContent();
            })
            .RequireAuthorization("Admin");

            group.MapGet("/{stepId}/eligible-disciples", async (string stepId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var result = await mediator.Send(new GetEligibleStepDisciplesQuery
                {
                    RequestorId = requestorId,
                    StepId = stepId
                });
                return Results.Ok(result);
            });

            group.MapPut("/{stepId}/completions/{discipleId}", async (string stepId, string discipleId, [FromBody] UpdateStepCompletionRequest dto, IMediator mediator) =>
            {
                await mediator.Send(new UpdateStepCompletionCommand
                {
                    StepId = stepId,
                    DiscipleId = discipleId,
                    StepStatus = dto.Status,
                    CompletionDate = dto.CompletionDate
                });
                return Results.NoContent();
            });

            group.MapPost("/{stepId}/completions", async (string stepId, [FromBody] CompleteStepRequest dto, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                await mediator.Send(new CompleteStepForDisciplesCommand
                {
                    StepId = stepId,
                    LeaderId = requestorId,
                    DiscipleDocuments = dto.Documents,
                    CompletionDate = dto.CompletionDate
                });
                return Results.NoContent();
            });
        }
    }
}
