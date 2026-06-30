using JMMinistry.API.Extensions;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Features.User.Commands.ImportUsers;
using JMMinistry.Application.Features.User.Commands.RefreshToken;
using JMMinistry.Application.Features.User.Commands.Photo;
using JMMinistry.Application.Features.User.Commands.UpdateUser;
using JMMinistry.Application.Features.User.Queries.CheckDocumentExists;
using JMMinistry.Application.Features.User.Queries.GetUserInfo;
using JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria;
using JMMinistry.Application.Features.Location.Dtos;
using JMMinistry.Application.Common;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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

        [HttpPost("refresh")]
        public async Task<ActionResult<TokenResult>> RefreshToken(RefreshTokenCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(CreateUserCommand createUserCommand)
        {
            var result = await mediator.Send(createUserCommand);
            return new ContentResult { Content = result, StatusCode = StatusCodes.Status201Created, ContentType = MediaTypeNames.Text.Plain };
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
                Document = document ?? requestorId,
                RequestorDocument = requestorId
            });

            return Ok(userInfo);
        }

        [Authorize]
        [HttpGet("Check/{document}")]
        public async Task<ActionResult<DocumentCheckResultDto>> CheckDocumentExists(string document)
        {
            var result = await mediator.Send(new CheckDocumentExistsQuery { Document = document });
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<string>> UpdateUser(UpdateUserCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Search")]
        public async Task<ActionResult<PagedResponse<BasicUserInfoDto>>> GetUsersByCriteria(GetUserInfoByCriteriaQuery criteria)
        {
            var result = await mediator.Send(criteria);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("marry")]
        public async Task<ActionResult> MarryLeaders([FromBody] MarryLeadersDto dto)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            await mediator.Send(new MarryLeadersCommand
            {
                RequestorId = requestorId,
                PersonId = dto.PersonId,
                SpouseId = dto.SpouseId
            });

            return Ok(new { });
        }

        [Authorize]
        [HttpGet("{discipleId}/is-leader")]
        public async Task<ActionResult<bool>> IsLeaderInHierarchy(string discipleId)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = requestorId,
                DiscipleId = discipleId
            });

            return Ok(result);
        }

        [Authorize]
        [HttpGet("photo/upload-url")]
        public async Task<ActionResult<string>> GetPhotoUploadUrl([FromQuery] string fileName)
        {
            var result = await mediator.Send(new GetPhotoUploadUrlCommand { FileName = fileName });
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{document}/photo")]
        public async Task<ActionResult> DeletePhoto(string document)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
            await mediator.Send(new DeletePhotoCommand
            {
                RequestorId = requestorId,
                Document = document
            });
            return Ok(new { });
        }
    }
}
