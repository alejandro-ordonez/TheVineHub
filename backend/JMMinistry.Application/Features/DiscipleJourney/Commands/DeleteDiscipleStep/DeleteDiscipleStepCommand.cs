using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteDiscipleStep
{
    public class DeleteDiscipleStepCommand : ICommand
    {
        [Column("step_id")]
        public required string StepId { get; set; }
    }

    public class DeleteDiscipleStepValidator : AbstractValidator<DeleteDiscipleStepCommand>
    {
        public DeleteDiscipleStepValidator()
        {
            RuleFor(x => x.StepId).NotEmpty();
        }
    }
}
