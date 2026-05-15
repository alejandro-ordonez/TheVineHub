using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateCommand : AuthenticateDto, ICommand<TokenResult>
    {
    }
}
