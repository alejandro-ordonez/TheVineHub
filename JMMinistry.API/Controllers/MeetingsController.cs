using JMMinistry.API.Extensions;
using JMMinistry.Application.Features.Meetings.Commands.CreateMeeting;
using JMMinistry.Application.Features.Meetings.Queries.GetMeetings;
using JMMinistry.Common.Dtos.Meetings;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MeetingsController(IMediator mediator, IOutputCacheStore cache) : ControllerBase
    {
        // GET: api/<MeetingsController>
        [HttpGet]
        [OutputCache(PolicyName = CacheTags.Meetings)]
        public async Task<ActionResult<IEnumerable<MeetingDto>>> Get()
        {
            var command = new GetMeetingsQuery();
            var result = await mediator.Send(command);

            return Ok(result);
        }

        // GET api/<MeetingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MeetingsController>
        [HttpPost]
        public async Task<ActionResult<MeetingDto>> Create(CreateMeetingCommand meetingDto)
        {
            var result = await mediator.Send(meetingDto);
            await cache.EvictByTagAsync(CacheTags.Meetings, default);
            return Ok(result);
        }

        // PUT api/<MeetingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeetingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
