using JMMinistry.Application.User.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.User.Commands.Authenticate
{
    public class AuthenticateCommand: IRequest<TokenResult>
    {
        [Required]
        public string Document { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
