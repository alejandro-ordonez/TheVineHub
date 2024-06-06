using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateCommand : AuthenticateDto, IRequest<TokenResult>
    {
    }
}
