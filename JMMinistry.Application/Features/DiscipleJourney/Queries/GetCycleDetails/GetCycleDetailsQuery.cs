using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleDetails
{
    public class GetCycleDetailsQuery : IQuery<IList<CycleEnrollmentDto>>
    {
        public required int CycleId { get; set; }
    }

    public class GetCycleDetailsValidator : AbstractValidator<GetCycleDetailsQuery>
    {
        public GetCycleDetailsValidator()
        {
            RuleFor(x => x.CycleId).GreaterThan(0);
        }
    }
}
