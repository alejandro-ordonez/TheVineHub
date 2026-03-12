using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Extensions;
using JMMinistry.Domain;
using Mediator;
using Microsoft.AspNetCore.Identity;

namespace JMMinistry.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserHandler(
        UserManager<PersonalInfo> userManager
        )
        : ICommandHandler<UpdateUserCommand, string>
    {
        public async ValueTask<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Document)
                ?? throw new NotFoundException<PersonalInfo>(request.Document);

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.PhoneNumber = request.Phone;
            user.Email = request.Email;
            user.Birthday = request.Birthday;
            user.Gender = request.Gender;
            user.MaritalStatus = request.MaritalStatus ?? 0;
            user.EducationalLevel = request.EducationalLevel;
            user.Profession = request.Profession;
            user.Occupation = request.Occupation;
            user.City = request.City;
            user.Locality = request.Locality;
            user.Neighborhood = request.Neighborhood;
            user.Address = request.Address;

            var result = await userManager.UpdateAsync(user);
            result.ThrowOnError();

            return "User updated successfully";
        }
    }
}
