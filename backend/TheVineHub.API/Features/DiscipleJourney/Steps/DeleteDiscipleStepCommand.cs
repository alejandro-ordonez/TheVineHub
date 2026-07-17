using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class DeleteDiscipleStepCommand : ICommand
    {
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
