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
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff
{
    public class AddCycleStaffCommand : ICommand<CycleStaffDto>
    {
        [Column("cycle_id")]
        public required string CycleId { get; set; }
        [Column("person_id")]
        public required string PersonId { get; set; }
        [Column("role")]
        public CycleStaffRole Role { get; set; }
    }

    public class AddCycleStaffValidator : AbstractValidator<AddCycleStaffCommand>
    {
        public AddCycleStaffValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.Role).IsInEnum();
        }
    }
}
