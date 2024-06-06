using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : UserInfoDto, IRequest
    {
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
