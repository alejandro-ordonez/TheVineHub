using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries
{
    public class GetUserInfoHandler : IRequestHandler<GetUserInfoQuery, UserInfoDto>
    {
        public Task<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
