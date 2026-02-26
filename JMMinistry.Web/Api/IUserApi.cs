using JMMinistry.Common;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using Microsoft.AspNetCore.Components.Forms;

namespace JMMinistry.Web.Api
{
    public interface IUserApi
    {
        Task<Response<TokenResult?>?> Authenticate(AuthenticateDto authenticateDto);
        Task<Response<UserInfoDto>?> GetUserInfo(string? document = null);
        Task<Response<PagedResponse<PartialUserInfoDto>>?> GetUserByCriteria(UsersSearchCriteria? userCriteriaSearch);
        Task<Response<object>?> ImportUsers(IBrowserFile file);
        Task<Response<object>?> CreateUser(CreateUserInfoDto createUserDto);
        Task<Response<object>?> UpdateUser(CreateUserInfoDto dto);
        Task<Response<DocumentCheckResultDto>?> CheckDocumentExists(string document);
        Task<Response<bool>?> IsLeaderOfAsync(string discipleId);
    }
}
