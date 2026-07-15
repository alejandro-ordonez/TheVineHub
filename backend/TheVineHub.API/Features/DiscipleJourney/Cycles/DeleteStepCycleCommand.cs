using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles
{
    public class DeleteStepCycleCommand : ICommand
    {
        public required string StepId { get; set; }
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
