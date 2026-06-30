using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.DiscipleJourney.Dtos;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleEnrollments
{
    public class GetCycleEnrollmentsQuery : IQuery<IList<CycleEnrollmentDto>>
    {
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("cycle_id")]
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
