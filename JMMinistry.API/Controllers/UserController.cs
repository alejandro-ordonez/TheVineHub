using JMMinistry.API.Extensions;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.ImportUsers;
using JMMinistry.Application.Features.User.Queries;
using JMMinistry.Application.Features.User.Queries.GetUserInfo;
using JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria;
using JMMinistry.Common.Dtos.Common;
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
        [HttpPost("import")]
        public async Task<ActionResult<string>> Import(IFormFile formFile)
        {
            if (formFile == null)
                return BadRequest("File not submitted");

            var result = await mediator.Send(new ImportUsersCommand { File = formFile });
            return Ok(result);
        }


        [Authorize]
        [HttpGet("{document?}")]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo(string? document = null)
        {
            var requestorId = HttpContext.GetDocumentClaim();

            if (string.IsNullOrEmpty(requestorId))
                throw new ArgumentException("Your token must be included");

            var userInfo = await mediator.Send(new GetUserInfoQuery 
            { 
                Document =  document ?? requestorId,
                RequestorDocument = requestorId
            });

            return Ok(userInfo);
        }

        [Authorize]
        [HttpPost("Search")]
        public async Task<ActionResult<PagedResponse<PartialUserInfoDto>>> GetUsersByCriteria(GetUserInfoByCriteriaQuery criteria)
        {
            var result = await mediator.Send(criteria);
            return Ok(result);
        }
    }
}
