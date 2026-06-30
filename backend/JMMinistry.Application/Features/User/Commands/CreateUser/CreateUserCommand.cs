using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : CreateUserInfoDto, ICommand<string>
    {
    }
}
