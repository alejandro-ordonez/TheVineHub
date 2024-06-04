using JMMinistry.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.User.Commands.CreateUser
{
    public class CreateUserHandler(
        UserManager<PersonalInfo> userManager,
        RoleManager<Ministry> roleManager) : IRequestHandler<CreateUserCommand>
    {
        public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
