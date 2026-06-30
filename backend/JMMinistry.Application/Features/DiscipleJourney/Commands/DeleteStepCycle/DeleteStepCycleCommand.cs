using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteStepCycle
{
    public class DeleteStepCycleCommand : ICommand
    {
        [Column("step_id")]
        public required string StepId { get; set; }
        [Column("cycle_id")]
        public required string CycleId { get; set; }
    }

    public class DeleteStepCycleValidator : AbstractValidator<DeleteStepCycleCommand>
    {
        public DeleteStepCycleValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
            RuleFor(x => x.StepId).NotEmpty();
        }
    }
}
