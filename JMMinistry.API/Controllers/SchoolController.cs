using JMMinistry.Application.Features.Schools.Commands.CreateSchool;
using JMMinistry.Application.Features.Schools.Queries.GetSchoolById;
using JMMinistry.Application.Features.Schools.Queries.GetSchools;
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
            var school = await mediator.Send(new GetSchoolByIdCommand { SchoolId = schoolId });
            return Ok(school);
        }

        [HttpGet]
        public async Task<ActionResult<Response<ICollection<SchoolDto>>>> GetSchools()
        {
            var schools = await mediator.Send(new GetSchoolsCommand());
            return Ok(schools);
        }


        [HttpGet("attendance")]



        [HttpPost]
        public async Task<ActionResult<Response<SchoolDto>>> CreateSchool(SchoolDto schoolDto)
        {
            var school = await mediator.Send(new UpsertSchoolCommand { Id = default, Name = schoolDto.Name, Description = schoolDto.Description });
            return Ok(school);
        }

        [HttpPut]
        public async Task<ActionResult<Response<SchoolDto>>> UpdateSchool(SchoolDto schoolDto)
        {
            var school = await mediator.Send(new UpsertSchoolCommand { Id = schoolDto.Id, Name = schoolDto.Name, Description = schoolDto.Description });
            return Ok(school);
        }
    }
}
