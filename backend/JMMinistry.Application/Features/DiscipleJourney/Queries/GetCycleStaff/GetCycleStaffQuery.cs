using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleStaff
{
    public class GetCycleStaffQuery : IQuery<IList<CycleStaffDto>>
    {
        public required string CycleId { get; set; }
    }

    public class GetCycleStaffValidator : AbstractValidator<GetCycleStaffQuery>
    {
        public GetCycleStaffValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}
