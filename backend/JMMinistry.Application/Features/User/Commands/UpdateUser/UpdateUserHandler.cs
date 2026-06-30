using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;

namespace JMMinistry.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserHandler(ISurrealDbSession session)
        : ICommandHandler<UpdateUserCommand, string>
    {
        public async ValueTask<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Check if user exists
            var existingUserQuery = await session.Query($"SELECT * FROM {request.Id}", cancellationToken);
            var existingUser = existingUserQuery.GetValue<List<UserInfoDto>>(0)?.FirstOrDefault();
            if (existingUser is null)
                throw new NotFoundException<UserInfoDto>(request.Id?.ToString() ?? "Unknown");

            var result = await session.Query(@$"
                {{
                    RETURN UPDATE {request.Id} SET
                        email = {request.Email},
                        phone = {request.Phone} OR NONE,
                        birthday = {request.Birthday?.ToDateTime(TimeOnly.MinValue)} OR NONE,
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
                    throw new Exception($"SurrealDB Error: {errorRes.Details}");

                throw new Exception($"SurrealDB Error: {error}");
            }

            return "User updated successfully";
        }
    }
}
