using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Extensions;
using JMMinistry.Application.Mappers;
using JMMinistry.Common;
using JMMinistry.Domain;
using Mediator;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserHandler(
        UserManager<PersonalInfo> userManager,
        AppMapper mapper
        )
        : ICommandHandler<CreateUserCommand, string>
    {
        public async ValueTask<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Password))
                request.Password = $"User.{request.Document}";

            var existing = await userManager.FindByIdAsync(request.Document);
            if (existing is not null)
                throw new EntityAlreadyExistsException<PersonalInfo>(request.Document);

            var personalInfo = mapper.UserInfoDtoToPersonalInfo(request);

            var result = await userManager.CreateAsync(personalInfo, request.Password);
            result.ThrowOnError();

            result = await userManager.AddToRoleAsync(personalInfo, Roles.Regular.ToString());
            result.ThrowOnError();

            return "User created successfully";
        }
    }
}
