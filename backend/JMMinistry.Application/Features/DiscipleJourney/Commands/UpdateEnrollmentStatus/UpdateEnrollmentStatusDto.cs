using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus
{
    public class UpdateEnrollmentStatusDto
    {
        [Column("status")]
        public StepStatus Status { get; set; }
    }
}
