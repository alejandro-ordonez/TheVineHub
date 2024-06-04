using JMMinistry.Application.User.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.User.Commands.Authenticate
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, TokenResult>
    {
        public Task<TokenResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
