using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleDetails
{
    public class GetCycleDetailsQuery : IQuery<IList<CycleEnrollmentDto>>
    {
        public required string CycleId { get; set; }
    }

    public class GetCycleDetailsValidator : AbstractValidator<GetCycleDetailsQuery>
    {
        public GetCycleDetailsValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}
