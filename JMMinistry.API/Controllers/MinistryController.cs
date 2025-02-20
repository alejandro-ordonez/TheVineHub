using JMMinistry.API.Extensions;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using JMMinistry.Application.Features.Cells.Commands.CreateCell;
using JMMinistry.Application.Features.Cells.Queries.GetCells;
using JMMinistry.Common.Dtos.Cell;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinistryController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<CellDto>> CreateCell(CreateCellCommand createCellCommand)
        {
            createCellCommand.Document = HttpContext.GetDocumentClaim() ?? throw new ArgumentException("Missing document in token");
            var cell = await mediator.Send(createCellCommand);
            return Created(string.Empty, cell);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CellDto>>> GetCells()
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new ArgumentException("Missing document in token");

            var cells = await mediator.Send(new GetCellsCommand { Document = document });
            return Ok(cells);
        }

        [HttpPost("{cellId}")]
        public async Task<ActionResult<CellDto>> AddDisciples(int cellId, [FromBody] AddDisciplesCommand addDisciples)
        {
            addDisciples.CellId = cellId;

            var cell = await mediator.Send(addDisciples);
            return cell;
        }
    }
}
