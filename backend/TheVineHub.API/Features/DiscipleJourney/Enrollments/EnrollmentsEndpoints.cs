using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
{
    public class EnrollmentsEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/disciplejourney/cycles/{cycleId}/enrollments").RequireAuthorization();

            group.MapPost("", async (string cycleId, [FromBody] EnrollDisciplesRequest dto, HttpContext httpContext, IMediator mediator, IOutputCacheStore cache) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                await mediator.Send(new EnrollDisciplesCommand
                {
                    CycleId = cycleId,
                    LeaderId = requestorId,
                    DiscipleIds = dto.DiscipleIds,
                    InitialStatus = dto.InitialStatus
                });

                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.NoContent();
            });

            group.MapPut("/{enrollmentId}/status", async (string cycleId, string enrollmentId, [FromBody] UpdateEnrollmentStatusRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                await mediator.Send(new UpdateEnrollmentStatusCommand
                {
                    CycleId = cycleId,
                    EnrollmentId = enrollmentId,
                    Status = dto.Status
                });

                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.NoContent();
            });

            group.MapPut("/assign-guide", async (string cycleId, [FromBody] AssignGuideRequest dto, IMediator mediator, IOutputCacheStore cache) =>
            {
                await mediator.Send(new AssignGuideCommand
                {
                    CycleId = cycleId,
                    CycleStaffId = dto.CycleStaffId,
                    EnrollmentIds = dto.EnrollmentIds
                });

                await cache.EvictByTagAsync(CacheTags.CycleData, default);
                return Results.NoContent();
            });

            group.MapGet("", async (string cycleId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var result = await mediator.Send(new GetCycleEnrollmentsQuery
                {
                    RequestorId = requestorId,
                    CycleId = cycleId
                });
                return Results.Ok(result);
            });
        }
    }
}
