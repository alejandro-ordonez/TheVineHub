using JMMinistry.Application.Features.Meetings.Queries.GetMeetings;
using JMMinistry.Common.Dtos.Meetings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController(IMediator mediator) : ControllerBase
    {
        // GET: api/<MeetingsController>
        [HttpGet]
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
        public void Post([FromBody] string value)
        {
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
