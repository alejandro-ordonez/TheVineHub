using JMMinistry.Application.User.Commands.Authenticate;
using JMMinistry.Application.User.Commands.CreateUser;
using JMMinistry.Application.User.Dtos;
using JMMinistry.Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JMMinistry.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult> Register(CreateUserCommand createUserCommand)
        {
            await mediator.Send(createUserCommand);
            return Created();
        }

        [HttpPost("auth")]
        public async Task<ActionResult<TokenResult>> Authenticate(AuthenticateCommand authenticate)
        {
            return Ok(await mediator.Send(authenticate));
        }

        [HttpGet]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo()
        {
            var userInfo = await mediator.Send(new GetUserInfoQuery());
            return Ok(userInfo);
        }
    }
}
