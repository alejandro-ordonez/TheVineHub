using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep
{
    public class UpdateDiscipleStepCommand : ICommand<DiscipleStepDto>
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required StepCategory StepCategory { get; set; }
        public bool RequiresCycle { get; set; }
        public bool RequiresAdminApproval { get; set; }
        public IList<int> RequirementIds { get; set; } = [];
        public int? ParentStepId { get; set; }
    }

    public class UpdateDiscipleStepValidator : AbstractValidator<UpdateDiscipleStepCommand>
    {
        public UpdateDiscipleStepValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.StepCategory).IsInEnum();
        }
    }
}
