using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession
{
    public class CreateCycleSessionCommand : ICommand<CycleSessionDto>
    {
        public required string CycleId { get; set; }
        public DateOnly Date { get; set; }
        public string? Topic { get; set; }
    }

    public class CreateCycleSessionValidator : AbstractValidator<CreateCycleSessionCommand>
    {
        public CreateCycleSessionValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}
