using JMMinistry.Common;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using Microsoft.AspNetCore.Components.Forms;

namespace JMMinistry.Web.Api
{
    public interface IUserApi
    {
        Task<Response<TokenResult?>?> Authenticate(AuthenticateDto authenticateDto);
        Task<Response<UserInfoDto>?> GetUserInfo();
        Task<Response<PagedResponse<UserInfoDto>>?> GetUserByCriteria(UsersSearchCriteria? userCriteriaSearch);

        Task<Response<object>?> ImportUsers(IBrowserFile file);
    }
}
