using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetUserInfoQuery, UserInfoDto>
    {
        public async Task<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userInfo = await dbContext.PersonalInfo
                .FirstOrDefaultAsync(user => user.Id == request.Document, cancellationToken);

            var userInfoDto = mapper.Map<UserInfoDto>(userInfo);

            return userInfoDto;
        }
    }
}
