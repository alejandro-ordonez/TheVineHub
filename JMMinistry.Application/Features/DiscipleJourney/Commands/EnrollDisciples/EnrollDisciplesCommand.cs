using FluentValidation;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples
{
    public class EnrollDisciplesCommand : ICommand
    {
        public required int CycleId { get; set; }
        public required string LeaderId { get; set; }
        public IList<string> DiscipleIds { get; set; } = [];
        public StepStatus? InitialStatus { get; set; }
    }

    public class EnrollDisciplesValidator : AbstractValidator<EnrollDisciplesCommand>
    {
        public EnrollDisciplesValidator()
        {
            RuleFor(x => x.CycleId).GreaterThan(0);
            RuleFor(x => x.LeaderId).NotEmpty();
            RuleFor(x => x.DiscipleIds).NotEmpty();
        }
    }
}
