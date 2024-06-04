using JMMinistry.Application.User.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : UserInfoDto, IRequest
    {
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
