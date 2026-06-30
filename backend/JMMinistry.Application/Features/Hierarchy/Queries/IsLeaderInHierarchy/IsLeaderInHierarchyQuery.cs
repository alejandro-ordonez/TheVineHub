using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy
{
    public class IsLeaderInHierarchyQuery : IQuery<bool>
    {
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("disciple_id")]
        public required string DiscipleId { get; set; }
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
