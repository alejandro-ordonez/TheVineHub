using JMMinistry.Common.Dtos.User;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;

using System.Linq;

namespace JMMinistry.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserHandler(ISurrealDbSession session)
        : ICommandHandler<UpdateUserCommand, string>
    {
        public async ValueTask<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = $"user:{request.Id}";

            // Check if user exists
            var existingUser = await session.Select<UserInfoDto>(userId, cancellationToken);
            if (existingUser is null)
                throw new NotFoundException<UserInfoDto>(request.Id);

            var result = await session.Query(@$"
                UPDATE type::thing('user', {request.Id}) SET
                    email = {request.Email},
                    phone = {request.Phone},
                    birthday = {request.Birthday?.ToDateTime(TimeOnly.MinValue)},
                    marital_status = {request.MaritalStatus.ToString()},
                    educational_level = {request.EducationalLevel?.ToString()},
                    profession = {request.Profession},
                    occupation = {request.Occupation},
                    address = {request.Address},
                    neighborhood = {request.Neighborhood},
                    city = {request.City},
                    locality = {request.Locality},
                    photo_path = {request.PhotoPath};
            ", cancellationToken);

            return "User updated successfully";
        }
    }
}
