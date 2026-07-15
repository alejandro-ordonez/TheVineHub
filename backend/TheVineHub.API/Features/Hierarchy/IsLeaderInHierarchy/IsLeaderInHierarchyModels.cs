using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.Hierarchy.IsLeaderInHierarchy
{
    public sealed class IsLeaderInHierarchyQuery : IQuery<bool>
    {
        public required string RequestorId { get; init; }
        public required string DiscipleId { get; init; }
    }

    public class IsLeaderInHierarchyValidator : AbstractValidator<IsLeaderInHierarchyQuery>
    {
        public IsLeaderInHierarchyValidator()
        {
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
        }
    }
}
