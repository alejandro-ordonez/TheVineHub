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

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetStepDisciples
{
    public class GetStepDisciplesQuery : IQuery<IList<StepDisciplesByCellDto>>
    {
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("step_id")]
        public required string StepId { get; set; }
        [Column("cell_id")]
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
