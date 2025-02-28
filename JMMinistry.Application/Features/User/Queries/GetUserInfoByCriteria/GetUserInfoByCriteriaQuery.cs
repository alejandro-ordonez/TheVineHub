using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaQuery: UsersSearchCriteria, IRequest<PagedResponse<UserInfoDto>>
    {
    }
}
