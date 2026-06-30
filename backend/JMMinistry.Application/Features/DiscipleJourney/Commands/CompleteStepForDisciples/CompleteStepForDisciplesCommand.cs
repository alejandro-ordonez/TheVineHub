using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples
{
    public class CompleteStepForDisciplesCommand : ICommand
    {
        [Column("step_id")]
        public required string StepId { get; set; }
        [Column("leader_id")]
        public required string LeaderId { get; set; }
        [Column("disciple_documents")]
        public required IList<string> DiscipleDocuments { get; set; }
        [Column("completion_date")]
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
