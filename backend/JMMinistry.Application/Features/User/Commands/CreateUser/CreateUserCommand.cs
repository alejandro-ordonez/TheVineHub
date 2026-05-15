using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : CreateUserInfoDto, ICommand<string>
    {
    }
}
