using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleSessions
{
    public class GetCycleSessionsQuery : IQuery<IList<CycleSessionDto>>
    {
        public required int CycleId { get; set; }
    }

    public class GetCycleSessionsValidator : AbstractValidator<GetCycleSessionsQuery>
    {
        public GetCycleSessionsValidator()
        {
            RuleFor(x => x.CycleId).GreaterThan(0);
        }
    }
}
