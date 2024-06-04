using JMMinistry.Application.Features.User.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<TokenResult>
    {
        public string Document { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
