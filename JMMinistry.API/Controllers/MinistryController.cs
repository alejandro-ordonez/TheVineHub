using JMMinistry.API.Attributes;
using JMMinistry.Application.Features.Cell.Queries.GetCells;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CellDto>>> GetCells([Id] string document)
        {
            var cells = await mediator.Send(new GetCellsCommand { Document = document });
            return Ok(cells);
        }
    }
}
