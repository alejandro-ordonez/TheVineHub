using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetEligibleStepDisciples
{
    public class GetEligibleStepDisciplesQuery : IQuery<IList<StepDisciplesByCellDto>>
    {
        public required string RequestorId { get; set; }
        public required string StepId { get; set; }
    }

    public class GetEligibleStepDisciplesValidator : AbstractValidator<GetEligibleStepDisciplesQuery>
    {
        public GetEligibleStepDisciplesValidator()
        {
            RuleFor(x => x.RequestorId).NotEmpty();
            RuleFor(x => x.StepId).NotEmpty();
        }
    }
}
