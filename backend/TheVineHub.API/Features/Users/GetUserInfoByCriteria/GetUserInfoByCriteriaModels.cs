using TheVineHub.API.Features.Locations;
using TheVineHub.API.Common;
using TheVineHub.API.Features.Users;
using TheVineHub.API.Features.Users.Authenticate;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users.MarryLeaders;
using Mediator;

namespace TheVineHub.API.Features.Users.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaQuery : UsersSearchCriteria, IQuery<PagedResponse<BasicUserInfoDto>>
    {
    }
}
