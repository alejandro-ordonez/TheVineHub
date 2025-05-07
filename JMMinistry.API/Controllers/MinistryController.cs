using JMMinistry.API.Extensions;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using JMMinistry.Application.Features.Cells.Commands.CreateCell;
using JMMinistry.Application.Features.Cells.Commands.RecordAttendance;
using JMMinistry.Application.Features.Cells.Commands.RemoveDisciple;
using JMMinistry.Application.Features.Cells.Queries.GetCell;
using JMMinistry.Application.Features.Cells.Queries.GetCellAttendances;
using JMMinistry.Application.Features.Cells.Queries.GetCells;
using JMMinistry.Application.Features.Cells.Queries.GetDisciples;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MinistryController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<CellDto>> CreateCell(UpsertCellCommand createCellCommand)
        {
            createCellCommand.Document = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
            var cell = await mediator.Send(createCellCommand);
            return Ok(cell);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CellDto>>> GetCells()
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var cells = await mediator.Send(new GetCellsQuery { Document = document });
            return Ok(cells);
        }

        [HttpGet("{cellId}")]
        public async Task<ActionResult<CellDto>> GetCell(int cellId)
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var cells = await mediator.Send(new GetCellQuery { RequestorId = document, CellId = cellId });
            return Ok(cells);
        }


        [HttpGet("attendances/{cellId}")]
        public async Task<ActionResult> GetCellAttendances(int cellId)
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var query = new GetCellAttendancesQuery { CellId = cellId, RequestorId = document };
            var result = await mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("attendances/{cellId}")]
        public async Task<ActionResult> RecordCellAttendance(int cellId, AddCellAttendanceDto cellAttendance)
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var command = new RecordAttendanceCommand
            {
                CellId = cellId,
                RequestorId = document,
                Attendees = cellAttendance.Disciples,
                Notes = cellAttendance.Notes
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCell(UpsertCellCommand upsertCellCommand)
        {
            upsertCellCommand.Document = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
            var cell = await mediator.Send(upsertCellCommand);
            return Ok(cell);
        }


        [HttpGet("disciples/{cellId}")]
        public async Task<ActionResult<List<PartialUserInfoDto>>> GetDisciples(int cellId)
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var query = new GetDisciplesQuery
            {
                CellId = cellId,
                RequestorId = document
            };

            var response = await mediator.Send(query);

            return Ok(response);
        }


        [HttpPost("disciples/{cellId}")]
        public async Task<ActionResult<List<PartialUserInfoDto>>> AddDisciples(int cellId, [FromBody] AddDisciplesCommand addDisciples)
        {
            addDisciples.CellId = cellId;

            var cell = await mediator.Send(addDisciples);
            return Ok(cell);
        }

        [HttpDelete("disciples/{cellId}/{discipleId}")]
        public async Task<ActionResult<List<PartialUserInfoDto>>> RemoveDisciple(int cellId, string discipleId)
        {
            var removeDiscipleCommand = new RemoveDiscipleCommand { CellId = cellId, Document = discipleId };
            var result = await mediator.Send(removeDiscipleCommand);
            return Ok(result);
        }
    }
}
