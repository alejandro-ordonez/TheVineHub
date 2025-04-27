using JMMinistry.Common.Dtos.User;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : UserInfoDto, IRequest
    {
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
