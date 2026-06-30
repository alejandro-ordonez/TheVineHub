using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;

namespace JMMinistry.Application.Features.DiscipleJourney.Dtos
{
    public class StepDiscipleDto : BasicUserInfoDto
    {
        [Column("step_status")]
        public StepStatus? StepStatus { get; set; }
        [Column("last_updated")]
        public DateOnly LastUpdated { get; set; }
        [Column("cycle_enrollment_summary")]
        public CycleEnrollmentSummaryDto? CycleEnrollmentSummary { get; set; }
    }
}
