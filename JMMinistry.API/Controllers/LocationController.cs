using JMMinistry.Application.Features.Location.GetLocationData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetLocationData()
        {
            var result = await mediator.Send(new GetLocationDataQuery());
            return Ok(result);
        }
    }
}
