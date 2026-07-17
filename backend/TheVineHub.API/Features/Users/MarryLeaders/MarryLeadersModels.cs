using Mediator;
using FluentValidation;

namespace TheVineHub.API.Features.Users.MarryLeaders
{
    public sealed record MarryLeadersRequest(string PersonId, string SpouseId);

    public sealed class MarryLeadersCommand : ICommand
    {
        public required string RequestorId { get; init; }
        public required string PersonId { get; init; }
        public required string SpouseId { get; init; }
    }

    public class MarryLeadersValidator : AbstractValidator<MarryLeadersCommand>
    {
        public MarryLeadersValidator()
        {
            RuleFor(x => x.RequestorId).NotEmpty();
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.SpouseId).NotEmpty();
            RuleFor(x => x.PersonId).NotEqual(x => x.SpouseId);
        }
    }
}
