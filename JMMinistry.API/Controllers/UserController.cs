using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.ImportUsers;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
        [HttpPost("import")]
        public async Task<ActionResult> Import(IFormFile formFile)
        {
            if (formFile == null)
                return BadRequest("File not submitted");

            await mediator.Send(new ImportUsersCommand { File = formFile });
            return Ok();
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo()
        {
            var documentClaim = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub);
            var document = documentClaim?.Value ?? throw new ArgumentException("It was not possible to retrieve your document");

            var userInfo = await mediator.Send(new GetUserInfoQuery { Document =  document });
            return Ok(userInfo);
        }
    }
}
