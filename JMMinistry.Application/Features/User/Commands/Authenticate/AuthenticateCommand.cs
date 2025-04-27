using JMMinistry.Common.Dtos.User;
using MediatR;

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateCommand : AuthenticateDto, IRequest<TokenResult>
    {
    }
}
