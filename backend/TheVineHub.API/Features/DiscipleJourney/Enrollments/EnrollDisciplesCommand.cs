using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using TheVineHub.API.Features.DiscipleJourney;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
{
    public class EnrollDisciplesCommand : ICommand
    {
        public required string CycleId { get; set; }
        public required string LeaderId { get; set; }
        public IList<string> DiscipleIds { get; set; } = [];
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
