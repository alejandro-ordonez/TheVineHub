using JMMinistry.Application.Features.Location.GetLocationData;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [OutputCache(Duration = 86400)]
        public async Task<ActionResult> GetLocationData()
        {
            var result = await mediator.Send(new GetLocationDataQuery());
            return Ok(result);
        }
    }
}
