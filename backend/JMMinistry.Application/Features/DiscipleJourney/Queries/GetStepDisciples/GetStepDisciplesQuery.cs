using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepDisciples
{
    public class GetStepDisciplesQuery : IQuery<IList<StepDisciplesByCellDto>>
    {
        public required string RequestorId { get; set; }
        public required string StepId { get; set; }
        public string? CellId { get; set; }
    }

    public class GetStepDisciplesValidator : AbstractValidator<GetStepDisciplesQuery>
    {
        public GetStepDisciplesValidator()
        {
            RuleFor(x => x.RequestorId).NotEmpty();
            RuleFor(x => x.StepId).NotEmpty();
        }
    }
}
