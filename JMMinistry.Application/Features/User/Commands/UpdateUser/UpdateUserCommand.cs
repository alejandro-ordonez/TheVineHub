using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : UserInfoDto, ICommand<string>
    {
    }
}
