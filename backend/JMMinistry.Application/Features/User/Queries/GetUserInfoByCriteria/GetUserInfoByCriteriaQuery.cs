using JMMinistry.Application.Features.Location.Dtos;
using JMMinistry.Application.Common;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaQuery : UsersSearchCriteria, IQuery<PagedResponse<BasicUserInfoDto>>
    {
    }
}
