using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Services
{
    public interface IAuthService
    {
        Task<bool> AuthenticateAsync(AuthenticateDto authenticateDto);
    }
}
