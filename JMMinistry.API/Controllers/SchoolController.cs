using JMMinistry.Application.Features.School.Queries.GetSchoolById;
using JMMinistry.Application.Features.School.Queries.GetSchools;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.School;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SchoolController(IMediator mediator) : ControllerBase
    {

        [HttpGet("{schoolId}")]
        public async Task<ActionResult<Response<SchoolDto>>> GetSchool(int schoolId)
        {
            var school = await mediator.Send(new GetSchoolByIdCommand {SchoolId = schoolId});

            if (school == null)
                return NotFound();

            return Ok(school);
        }

        [HttpGet]
        public async Task<ActionResult<Response<ICollection<SchoolDto>>>> GetSchools()
        {
            var schools = await mediator.Send(new GetSchoolsCommand());
            
            if(schools.IsNullOrEmpty())
                return NoContent();

            return Ok(schools);
        }
    }
}
