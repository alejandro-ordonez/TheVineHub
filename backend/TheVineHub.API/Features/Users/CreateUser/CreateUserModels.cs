using Mediator;
using FluentValidation;
using TheVineHub.API.Features.Users;

namespace TheVineHub.API.Features.Users.CreateUser
{
    public sealed class CreateUserCommand : ICommand<string>
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public required string LastName { get; init; }
        public string? Password { get; init; }
        public string Email { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public DateOnly? Birthday { get; init; }
        public Gender Gender { get; init; }
        public MaritalStatus? MaritalStatus { get; init; }
        public EducationalLevel? EducationalLevel { get; init; }
        public string Profession { get; init; } = string.Empty;
        public string Occupation { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
        public string Neighborhood { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string? Locality { get; init; }
        public string? PhotoPath { get; init; }
    }

    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }
    }
}
