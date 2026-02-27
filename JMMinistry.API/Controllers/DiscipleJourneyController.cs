using JMMinistry.API.Extensions;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetDiscipleSteps;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetEligibleStepDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepDisciples;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.User;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiscipleJourneyController(IMediator mediator) : ControllerBase
    {
        [HttpGet("steps")]
        [ResponseCache(Duration = 86400)]
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
                RequirementIds = dto.RequirementIds
            });

            return Ok(result);
        }

        [HttpDelete("steps/{stepId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteStep(int stepId)
        {
            await mediator.Send(new DeleteDiscipleStepCommand { StepId = stepId });
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
    }
}
