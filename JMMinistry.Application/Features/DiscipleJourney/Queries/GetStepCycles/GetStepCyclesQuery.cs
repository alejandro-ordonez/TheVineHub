using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepCycles
{
    public class GetStepCyclesQuery : IQuery<IList<StepCycleDto>>
    {
        public required int StepId { get; set; }
    }

    public class GetStepCyclesValidator : AbstractValidator<GetStepCyclesQuery>
    {
        public GetStepCyclesValidator()
        {
            RuleFor(x => x.StepId).GreaterThan(0);
        }
    }
}
