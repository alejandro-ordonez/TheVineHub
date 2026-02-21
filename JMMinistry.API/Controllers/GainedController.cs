using JMMinistry.API.Extensions;
using JMMinistry.Application.Features.Gain.Commands.RegisterGained;
using JMMinistry.Application.Features.Gain.Queries.GetGained;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.Gained;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GainedController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Response<IList<GainedUser>>>> GetGainedUsers()
        {
            var document = HttpContext.GetDocumentClaim() ?? throw new ArgumentException("Missing document in token");
            var query = new GetGainedQuery { Requestor = document };
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Response<GainedUser>>> RegisterGained(CreateGainedUser createGained)
        {

            var document = HttpContext.GetDocumentClaim() ?? throw new ArgumentException("Missing document in token");
            var command = new RegisterGainedCommand
            {
                GainedBy = document,
                GainedInfo = createGained
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
