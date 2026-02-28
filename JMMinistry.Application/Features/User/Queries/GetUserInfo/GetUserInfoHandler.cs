using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Services;
using JMMinistry.Application.Mappers;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoHandler(
        IJmDbContext dbContext,
        UserManager<PersonalInfo> userManager,
        AppMapper mapper,
        IMediator mediator
        ) : IQueryHandler<GetUserInfoQuery, UserInfoDto>
    {
        public async ValueTask<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userInfo = await dbContext.PersonalInfo
                .FirstOrDefaultAsync(user => user.Id == request.Document, cancellationToken) ??
                throw new NotFoundException("User not found");

            // Requesting self information
            if (request.RequestorDocument == request.Document)
            {
                var userInfoDto = mapper.PersonalInfoToUserInfoDto(userInfo);
                return userInfoDto;
            }

            // When no cell assigned another user can fetch this info to be added to a cell.
            if (userInfo.CellId is null)
                return mapper.PersonalInfoToUserInfoDto(userInfo);

            // Check permissions
            var requestor = new PersonalInfo { Id = request.RequestorDocument };

            var userRoles = await userManager.GetRolesAsync(requestor);
            var allowed = userRoles.Any(role => role == Roles.Admin.ToString() || role == Roles.Coordinator.ToString());

            if (allowed)
            {
                var userInfoDto = mapper.PersonalInfoToUserInfoDto(userInfo);
                userInfoDto.AccessType = AccessType.Admin;
                return userInfoDto;
            }

            // Check if they are in the same cell
            var areMates = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .AnyAsync(cell =>
                    cell.Id == userInfo.CellId &&
                    cell.Disciples.Any(disciple => disciple.Id == request.RequestorDocument),
                cancellationToken);

            if (areMates)
            {
                var userInfoDto = mapper.PersonalInfoToUserInfoDto(userInfo);
                userInfoDto.AccessType = AccessType.Mate;
                return userInfoDto;
            }

            // Check if it is the leader requesting this information
            var requestorIsTheLeader = await mediator.Send(new CellCheckIsAuthorizedQuery
            {
                CellId = userInfo.CellId.Value,
                RequestorId = request.RequestorDocument
            }, cancellationToken);

            if (requestorIsTheLeader)
            {
                var userInfoDto = mapper.PersonalInfoToUserInfoDto(userInfo);
                userInfoDto.AccessType = AccessType.Leader;
                return userInfoDto;
            }

            throw new NotAuthorizedException();
        }
    }
}
