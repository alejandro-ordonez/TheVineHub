using JMMinistry.API.Extensions;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.ImportUsers;
using JMMinistry.Application.Features.User.Queries;
using JMMinistry.Application.Features.User.Queries.GetUserInfo;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("auth")]
        public async Task<ActionResult<TokenResult>> Authenticate(AuthenticateCommand authenticate)
        {
            return Ok(await mediator.Send(authenticate));
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(CreateUserCommand createUserCommand)
        {
            await mediator.Send(createUserCommand);
            return Created();
        }

        [Authorize]
        [HttpPost("import/{importType}")]
        public async Task<ActionResult> Import(IFormFile formFile, ImportUserType importType)
        {
            if (formFile == null)
                return BadRequest("File not submitted");

            await mediator.Send(new ImportUsersCommand { File = formFile, ImportType = importType });
            return Ok();
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo()
        {
            var document = HttpContext.GetDocumentClaim();
            if (string.IsNullOrEmpty(document))
                throw new ArgumentException("Your token must be included");

            var userInfo = await mediator.Send(new GetUserInfoQuery { Document =  document });
            return Ok(userInfo);
        }

        [HttpGet("test")]
        public async Task<ActionResult<UserInfoDto>> TestDto()
        {
            await Task.Delay(100);
            return Ok(new UserInfoDto { Name = "Sup" });
        }
    }
}
