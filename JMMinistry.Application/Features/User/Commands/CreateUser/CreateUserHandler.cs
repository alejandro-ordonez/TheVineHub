using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Extensions;
using JMMinistry.Common;
using JMMinistry.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserHandler(
        UserManager<PersonalInfo> userManager,
        IMapper mapper
        )
        : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var _ = await userManager.FindByIdAsync(request.Document) ??
                throw new EntityAlreadyExistsException<PersonalInfo>(request.Document);

            var personalInfo = mapper.Map<PersonalInfo>(request);

            var result = await userManager.CreateAsync(personalInfo, request.Password);
            result.ThrowOnError();

            result = await userManager.AddToRoleAsync(personalInfo, Roles.Regular.ToString());
            result.ThrowOnError();
        }
    }
}
