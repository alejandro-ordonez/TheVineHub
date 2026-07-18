using TheVineHub.API.Common;
using TheVineHub.API.Features.Users;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;

using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Users.CreateUser
{
    public class CreateUserHandler(ISurrealDbSession session)
        : ICommandHandler<CreateUserCommand, string>
    {
        public async ValueTask<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Check if user already exists
            var parts = request.Id.Split(':', 2);
            var userId = parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From("user", request.Id);

            var existingUserQuery = await session.Query($"SELECT * FROM {userId}", cancellationToken);
            var existingUser = existingUserQuery.GetValue<List<UserInfoDto>>(0)?.FirstOrDefault();

            if (existingUser is not null)
                throw new EntityAlreadyExistsException<UserInfoDto>(request.Id?.ToString() ?? string.Empty);

            var result = await session.Query(@$"
                {{
                    RETURN CREATE {userId} SET
                        name = {request.Name},
                        last_name = {request.LastName},
                        email = {request.Email},
                        password = crypto::argon2::generate({request.Password}),
                        phone = {request.Phone} OR NONE,
                        birthday = {request.Birthday?.ToDateTime(TimeOnly.MinValue)} OR NONE,
                        gender = {request.Gender.ToString()},
                        marital_status = {request.MaritalStatus.ToString()},
                        educational_level = {request.EducationalLevel?.ToString()} OR NONE,
                        profession = {request.Profession} OR NONE,
                        occupation = {request.Occupation} OR NONE,
                        address = {request.Address} OR NONE,
                        neighborhood = {request.Neighborhood} OR NONE,
                        city = {request.City} OR NONE,
                        locality = {request.Locality} OR NONE,
                        photo_path = {request.PhotoPath} OR NONE;
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            return "User created successfully";
        }
    }
}
