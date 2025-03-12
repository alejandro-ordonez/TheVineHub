using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoHandler(
        IJmDbContext dbContext, 
        UserManager<PersonalInfo> userManager, 
        IMapper mapper
        ) : IRequestHandler<GetUserInfoQuery, UserInfoDto>
    {
        public async Task<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userInfo = await dbContext.PersonalInfo
                .FirstOrDefaultAsync(user => user.Id == request.Document, cancellationToken) ??
                throw new NotFoundException("User not found");

            // Requesting self information
            if (request.RequestorDocument == request.Document)
            {
                var userInfoDto = mapper.Map<UserInfoDto>(userInfo);
                return userInfoDto;
            }

            // Check permissions
            var requestor = new PersonalInfo { Id = request.RequestorDocument };

            var isAdmin = userManager.IsInRoleAsync(requestor, Roles.Admin.ToString());
            var isManager = userManager.IsInRoleAsync(requestor, Roles.Coordinator.ToString());

            var allowed = await Task.WhenAll(isAdmin, isManager);

            if(allowed.Any(task => task))
            {
                var userInfoDto = mapper.Map<UserInfoDto>(userInfo);
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
                var userInfoDto = mapper.Map<UserInfoDto>(userInfo);
                userInfoDto.AccessType = AccessType.Mate;
                return userInfoDto;
            }

            // Check if it is the leader requesting this information
            var requestorIsTheLeader = await dbContext.Cells
                .Include(cell => cell.Leaders)
                .AnyAsync(cell =>
                    cell.Id == userInfo.CellId &&
                    cell.Leaders.Any(leader => leader.Id == request.RequestorDocument),
                cancellationToken);

            if (requestorIsTheLeader)
            {
                var userInfoDto = mapper.Map<UserInfoDto>(userInfo);
                userInfoDto.AccessType = AccessType.Leader;
                return userInfoDto;
            }

            throw new NotAuthorizeException();
        }
    }
}
