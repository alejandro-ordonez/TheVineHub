using JMMinistry.API.Extensions;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using JMMinistry.Application.Features.Cells.Commands.CreateCell;
using JMMinistry.Application.Features.Cells.Commands.RemoveDisciple;
using JMMinistry.Application.Features.Cells.Queries.GetCells;
using JMMinistry.Application.Features.Cells.Queries.GetDisciples;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
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

            var cells = await mediator.Send(new GetCellsQuery { Document = document });
            return Ok(cells);
        }


        [HttpGet("disciples/{cellId}")]
        public async Task<ActionResult<PagedResponse<UserInfoDto>>> GetDisciples(int cellId, [FromQuery] PagedRequest pageRequest)
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new ArgumentException("Missing document in token");
            var query = new GetDisciplesQuery 
            { 
                CellId = cellId, 
                DocumentLeader = document,
                Page = pageRequest.Page,
                PageSize = pageRequest.PageSize,
                OrderByMember = pageRequest.OrderByMember,
                OrderDirection = pageRequest.OrderDirection
            };

            var response = await mediator.Send(query);

            return Ok(response);
        }


        [HttpPost("disciples/{cellId}")]
        public async Task<ActionResult<CellDto>> AddDisciples(int cellId, [FromBody] AddDisciplesCommand addDisciples)
        {
            addDisciples.CellId = cellId;

            var cell = await mediator.Send(addDisciples);
            return cell;
        }      

        [HttpDelete("disciples/{cellId}/{discipleId}")]
        public async Task<ActionResult<CellDto>> RemoveDisciple(int cellId, string discipleId)
        {
            var removeDiscipleCommand = new RemoveDiscipleCommand { CellId = cellId, Document = discipleId };
            var result = await mediator.Send(removeDiscipleCommand);
            return Ok(result);
        }
    }
}
