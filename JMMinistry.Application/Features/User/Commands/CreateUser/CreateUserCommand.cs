using JMMinistry.Common.Dtos.User;
using Mediator;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : CreateUserInfoDto, ICommand<string>
    {
    }
}
