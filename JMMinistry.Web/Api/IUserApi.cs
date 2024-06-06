using JMMinistry.Common;
using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Api
{
    public interface IUserApi
    {
        Task<Response<TokenResult?>?> Authenticate(AuthenticateDto authenticateDto);
    }
}
