using JMMinistry.Common;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Api
{
    public interface IUserApi
    {
        Task<Response<TokenResult?>?> Authenticate(AuthenticateDto authenticateDto);
        Task<Response<UserInfoDto>?> GetUserInfo();
        Task<Response<PagedResponse<UserInfoDto>>> GetUserByCriteria(UserCriteriaSearch userCriteriaSearch = null);
    }
}
