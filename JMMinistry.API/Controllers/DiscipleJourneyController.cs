using JMMinistry.API.Extensions;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteCycleSession;
using JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;
using JMMinistry.Application.Features.DiscipleJourney.Commands.RemoveCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetActiveCyclesForStep;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleAttendance;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleDetails;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleEnrollments;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleSessions;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetDiscipleSteps;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetEligibleStepDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepCycles;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepDisciples;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.User;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiscipleJourneyController(IMediator mediator, IOutputCacheStore cache) : ControllerBase
    {
        [HttpGet("steps")]
        [OutputCache(PolicyName = CacheTags.DiscipleSteps)]
        public async Task<ActionResult<IList<DiscipleStepDto>>> GetSteps()
        {
            var result = await mediator.Send(new GetDiscipleStepsQuery());
            return Ok(result);
        }

        [HttpGet("steps/{stepId:int}/disciples")]
        public async Task<ActionResult<IList<StepDisciplesByCellDto>>> GetStepDisciples(int stepId, [FromQuery] int? cellId = null)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new GetStepDisciplesQuery
            {
                RequestorId = requestorId,
                StepId = stepId,
                CellId = cellId
            });

            return Ok(result);
        }

        [HttpPost("steps")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<DiscipleStepDto>> CreateStep([FromBody] CreateDiscipleStepDto dto)
        {
            var result = await mediator.Send(new CreateDiscipleStepCommand
            {
                Name = dto.Name,
                Description = dto.Description,
                StepCategory = dto.StepCategory,
                RequiresCycle = dto.RequiresCycle,
                RequirementIds = dto.RequirementIds,
                ParentStepId = dto.ParentStepId
            });

            await cache.EvictByTagAsync(CacheTags.DiscipleSteps, default);
            return Ok(result);
        }

        [HttpPut("steps/{stepId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<DiscipleStepDto>> UpdateStep(int stepId, [FromBody] UpdateDiscipleStepDto dto)
        {
            var result = await mediator.Send(new UpdateDiscipleStepCommand
            {
                Id = stepId,
                Name = dto.Name,
                Description = dto.Description,
                StepCategory = dto.StepCategory,
                RequiresCycle = dto.RequiresCycle,
                RequirementIds = dto.RequirementIds,
                ParentStepId = dto.ParentStepId
            });

            await cache.EvictByTagAsync(CacheTags.DiscipleSteps, default);
            return Ok(result);
        }

        [HttpDelete("steps/{stepId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteStep(int stepId)
        {
            await mediator.Send(new DeleteDiscipleStepCommand { StepId = stepId });
            await cache.EvictByTagAsync(CacheTags.DiscipleSteps, default);
            return NoContent();
        }

        [HttpGet("steps/{stepId:int}/eligible-disciples")]
        public async Task<ActionResult<IList<StepDisciplesByCellDto>>> GetEligibleStepDisciples(int stepId)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new GetEligibleStepDisciplesQuery
            {
                RequestorId = requestorId,
                StepId = stepId
            });

            return Ok(result);
        }

        [HttpPut("steps/{stepId:int}/completions/{discipleId}")]
        public async Task<ActionResult> UpdateStepCompletion(int stepId, string discipleId, [FromBody] UpdateStepCompletionDto dto)
        {
            await mediator.Send(new UpdateStepCompletionCommand
            {
                StepId = stepId,
                DiscipleId = discipleId,
                StepStatus = (Domain.DiscipleJourney.StepStatus)(int)dto.Status,
                CompletionDate = dto.CompletionDate
            });

            return NoContent();
        }

        [HttpPost("steps/{stepId:int}/completions")]
        public async Task<ActionResult> CompleteStepForDisciples(int stepId, [FromBody] CompleteStepDto dto)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            await mediator.Send(new CompleteStepForDisciplesCommand
            {
                StepId = stepId,
                LeaderId = requestorId,
                DiscipleDocuments = dto.Documents,
                CompletionDate = dto.CompletionDate
            });

            return NoContent();
        }

        // ===== Step Cycles =====

        [HttpGet("steps/{stepId:int}/cycles")]
        [Authorize(Roles = "Admin")]
        [OutputCache(PolicyName = CacheTags.StepCycles)]
        public async Task<ActionResult<IList<StepCycleDto>>> GetStepCycles(int stepId)
        {
            var result = await mediator.Send(new GetStepCyclesQuery { StepId = stepId });
            return Ok(result);
        }

        [HttpGet("steps/{stepId:int}/cycles/active")]
        [OutputCache(PolicyName = CacheTags.StepCycles)]
        public async Task<ActionResult<IList<StepCycleDto>>> GetActiveCyclesForStep(int stepId)
        {
            var result = await mediator.Send(new GetActiveCyclesForStepQuery { StepId = stepId });
            return Ok(result);
        }

        [HttpPost("steps/{stepId:int}/cycles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<StepCycleDto>> CreateStepCycle(int stepId, [FromBody] CreateStepCycleDto dto)
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
            return Ok(result);
        }

        [HttpPut("steps/{stepId:int}/cycles/{cycleId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<StepCycleDto>> UpdateStepCycle(int stepId, int cycleId, [FromBody] UpdateStepCycleDto dto)
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
            return Ok(result);
        }

        [HttpDelete("steps/{stepId:int}/cycles/{cycleId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteStepCycle(int stepId, int cycleId)
        {
            await mediator.Send(new DeleteStepCycleCommand { StepId = stepId, CycleId = cycleId });
            await cache.EvictByTagAsync(CacheTags.StepCycles, default);
            return NoContent();
        }

        // ===== Cycle Sessions =====

        [HttpGet("cycles/{cycleId:int}/sessions")]
        [OutputCache(PolicyName = CacheTags.CycleData)]
        public async Task<ActionResult<IList<CycleSessionDto>>> GetCycleSessions(int cycleId)
        {
            var result = await mediator.Send(new GetCycleSessionsQuery { CycleId = cycleId });
            return Ok(result);
        }

        [HttpPost("cycles/{cycleId:int}/sessions")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CycleSessionDto>> CreateCycleSession(int cycleId, [FromBody] CreateCycleSessionDto dto)
        {
            var result = await mediator.Send(new CreateCycleSessionCommand
            {
                CycleId = cycleId,
                Date = dto.Date,
                Topic = dto.Topic
            });

            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return Ok(result);
        }

        [HttpDelete("cycles/{cycleId:int}/sessions/{sessionId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCycleSession(int cycleId, int sessionId)
        {
            await mediator.Send(new DeleteCycleSessionCommand { CycleId = cycleId, SessionId = sessionId });
            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return NoContent();
        }

        // ===== Cycle Staff =====

        [HttpGet("cycles/{cycleId:int}/staff")]
        [Authorize(Roles = "Admin")]
        [OutputCache(PolicyName = CacheTags.CycleData)]
        public async Task<ActionResult<IList<CycleStaffDto>>> GetCycleStaff(int cycleId)
        {
            var result = await mediator.Send(new GetCycleStaffQuery { CycleId = cycleId });
            return Ok(result);
        }

        [HttpPost("cycles/{cycleId:int}/staff")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CycleStaffDto>> AddCycleStaff(int cycleId, [FromBody] CreateCycleStaffDto dto)
        {
            var result = await mediator.Send(new AddCycleStaffCommand
            {
                CycleId = cycleId,
                PersonId = dto.PersonId,
                Role = dto.Role
            });

            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return Ok(result);
        }

        [HttpDelete("cycles/{cycleId:int}/staff/{staffId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveCycleStaff(int cycleId, int staffId)
        {
            await mediator.Send(new RemoveCycleStaffCommand { CycleId = cycleId, StaffId = staffId });
            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return NoContent();
        }

        // ===== Cycle Enrollments =====

        [HttpPost("cycles/{cycleId:int}/enrollments")]
        public async Task<ActionResult> EnrollDisciples(int cycleId, [FromBody] EnrollDisciplesDto dto)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            await mediator.Send(new EnrollDisciplesCommand
            {
                CycleId = cycleId,
                LeaderId = requestorId,
                DiscipleIds = dto.DiscipleIds
            });

            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return NoContent();
        }

        [HttpPut("cycles/{cycleId:int}/enrollments/{enrollmentId:int}/status")]
        public async Task<ActionResult> UpdateEnrollmentStatus(int cycleId, int enrollmentId, [FromBody] UpdateEnrollmentStatusDto dto)
        {
            await mediator.Send(new UpdateEnrollmentStatusCommand
            {
                CycleId = cycleId,
                EnrollmentId = enrollmentId,
                Status = dto.Status
            });

            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return NoContent();
        }

        [HttpPut("cycles/{cycleId:int}/enrollments/assign-guide")]
        public async Task<ActionResult> AssignGuide(int cycleId, [FromBody] AssignGuideDto dto)
        {
            await mediator.Send(new AssignGuideCommand
            {
                CycleId = cycleId,
                CycleStaffId = dto.CycleStaffId,
                EnrollmentIds = dto.EnrollmentIds
            });

            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return NoContent();
        }

        // ===== Cycle Attendance =====

        [HttpGet("cycles/{cycleId:int}/attendance")]
        [OutputCache(PolicyName = CacheTags.CycleData)]
        public async Task<ActionResult<IList<CycleAttendanceDto>>> GetCycleAttendance(int cycleId)
        {
            var result = await mediator.Send(new GetCycleAttendanceQuery { CycleId = cycleId });
            return Ok(result);
        }

        [HttpPost("cycles/{cycleId:int}/sessions/{sessionId:int}/attendance")]
        public async Task<ActionResult> RecordCycleAttendance(int cycleId, int sessionId, [FromBody] RecordCycleAttendanceDto dto)
        {
            await mediator.Send(new RecordCycleAttendanceCommand
            {
                CycleId = cycleId,
                SessionId = sessionId,
                DiscipleIds = dto.DiscipleIds
            });

            await cache.EvictByTagAsync(CacheTags.CycleData, default);
            return NoContent();
        }

        // ===== Cycle Details (admin) =====

        [HttpGet("cycles/{cycleId:int}/details")]
        [Authorize(Roles = "Admin")]
        [OutputCache(PolicyName = CacheTags.CycleData)]
        public async Task<ActionResult<IList<CycleEnrollmentDto>>> GetCycleDetails(int cycleId)
        {
            var result = await mediator.Send(new GetCycleDetailsQuery { CycleId = cycleId });
            return Ok(result);
        }

        [HttpGet("cycles/{cycleId:int}/enrollments")]
        public async Task<ActionResult<IList<CycleEnrollmentDto>>> GetCycleEnrollments(int cycleId)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new GetCycleEnrollmentsQuery
            {
                RequestorId = requestorId,
                CycleId = cycleId
            });

            return Ok(result);
        }
    }
}
