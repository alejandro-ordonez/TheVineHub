using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples
{
    public class EnrollDisciplesCommand : ICommand
    {
        [Column("cycle_id")]
        public required string CycleId { get; set; }
        [Column("leader_id")]
        public required string LeaderId { get; set; }
        [Column("disciple_ids")]
        public IList<string> DiscipleIds { get; set; } = [];
        [Column("initial_status")]
        public StepStatus? InitialStatus { get; set; }
    }

    public class EnrollDisciplesValidator : AbstractValidator<EnrollDisciplesCommand>
    {
        public EnrollDisciplesValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
            RuleFor(x => x.LeaderId).NotEmpty();
            RuleFor(x => x.DiscipleIds).NotEmpty();
        }
    }
}
