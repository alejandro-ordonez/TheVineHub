using JMMinistry.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.User.Commands.CreateUser
{
    public class CreateUserHandler(ISurrealDbSession session)
        : ICommandHandler<CreateUserCommand, string>
    {
        public async ValueTask<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Password))
                request.Password = $"User.{request.Id}";

            var userId = $"user:{request.Id}";

            // Check if user already exists
            var existingUser = await session.Select<UserInfoDto>(userId, cancellationToken);

            if (existingUser is not null)
                throw new EntityAlreadyExistsException<UserInfoDto>(request.Id ?? string.Empty);

            var result = await session.Query(@$"
                CREATE type::record('user', {request.Id}) SET
                    name = {request.Name},
                    last_name = {request.LastName},
                    email = {request.Email},
                    password = crypto::argon2::generate({request.Password}),
                    phone = {request.Phone},
                    birthday = {request.Birthday?.ToDateTime(TimeOnly.MinValue)},
                    gender = {request.Gender.ToString()},
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

            return "User created successfully";
        }
    }
}
