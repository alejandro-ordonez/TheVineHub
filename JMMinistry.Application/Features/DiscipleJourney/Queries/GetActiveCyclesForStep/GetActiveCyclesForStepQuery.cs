using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetActiveCyclesForStep
{
    public class GetActiveCyclesForStepQuery : IQuery<IList<StepCycleDto>>
    {
        public required int StepId { get; set; }
    }

    public class GetActiveCyclesForStepValidator : AbstractValidator<GetActiveCyclesForStepQuery>
    {
        public GetActiveCyclesForStepValidator()
        {
            RuleFor(x => x.StepId).GreaterThan(0);
        }
    }
}
