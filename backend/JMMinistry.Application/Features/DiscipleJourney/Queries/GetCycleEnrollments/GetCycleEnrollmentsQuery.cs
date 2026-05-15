using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleEnrollments
{
    public class GetCycleEnrollmentsQuery : IQuery<IList<CycleEnrollmentDto>>
    {
        public required string RequestorId { get; set; }
        public required string CycleId { get; set; }
    }

    public class GetCycleEnrollmentsValidator : AbstractValidator<GetCycleEnrollmentsQuery>
    {
        public GetCycleEnrollmentsValidator()
        {
            RuleFor(x => x.RequestorId).NotEmpty();
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}
