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

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle
{
    public class UpdateStepCycleCommand : ICommand<StepCycleDto>
    {
        [Column("step_id")]
        public required string StepId { get; set; }
        [Column("cycle_id")]
        public required string CycleId { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("start_date")]
        public DateOnly StartDate { get; set; }
        [Column("end_date")]
        public DateOnly EndDate { get; set; }
        [Column("min_attendance_required")]
        public int MinAttendanceRequired { get; set; }
        [Column("is_open")]
        public bool IsOpen { get; set; }
        [Column("enrollment_deadline")]
        public DateOnly? EnrollmentDeadline { get; set; }
    }

    public class UpdateStepCycleValidator : AbstractValidator<UpdateStepCycleCommand>
    {
        public UpdateStepCycleValidator()
        {
            RuleFor(x => x.CycleId).NotEmpty();
            RuleFor(x => x.StepId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate);
            RuleFor(x => x.MinAttendanceRequired).GreaterThan(0);
        }
    }
}
