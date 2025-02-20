using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserInfoDto>
    {
        public string Document { get; set; } = string.Empty;
    }
}
