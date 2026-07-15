using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class CompleteStepForDisciplesCommand : ICommand
    {
        public required string StepId { get; set; }
        public required string LeaderId { get; set; }
        public required IList<string> DiscipleDocuments { get; set; }
        public required DateOnly CompletionDate { get; set; }
    }

    public class CompleteStepForDisciplesValidator : AbstractValidator<CompleteStepForDisciplesCommand>
    {
        public CompleteStepForDisciplesValidator()
        {
            RuleFor(x => x.StepId).NotEmpty();
            RuleFor(x => x.LeaderId).NotEmpty();
            RuleFor(x => x.DiscipleDocuments).NotEmpty();
        }
    }
}
