using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep
{
    public class CreateDiscipleStepCommand : ICommand<DiscipleStepDto>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required StepCategory StepCategory { get; set; }
        public IList<int> RequirementIds { get; set; } = [];
    }

    public class CreateDiscipleStepValidator : AbstractValidator<CreateDiscipleStepCommand>
    {
        public CreateDiscipleStepValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.StepCategory).IsInEnum();
        }
    }
}
