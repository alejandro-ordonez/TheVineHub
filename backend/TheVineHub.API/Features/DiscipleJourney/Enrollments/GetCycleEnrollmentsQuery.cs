using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Sessions;
using TheVineHub.API.Features.DiscipleJourney.Staff;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Attendance;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
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
