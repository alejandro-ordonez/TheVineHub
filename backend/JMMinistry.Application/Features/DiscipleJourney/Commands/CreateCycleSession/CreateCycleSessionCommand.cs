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

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession
{
    public class CreateCycleSessionCommand : ICommand<CycleSessionDto>
    {
        [Column("cycle_id")]
        public required string CycleId { get; set; }
        [Column("date")]
        public DateOnly Date { get; set; }
        [Column("topic")]
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
