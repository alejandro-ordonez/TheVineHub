using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Dtos
{
    public class CycleStaffDto
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;
        [Column("step_cycle_id")]
        public string StepCycleId { get; set; } = string.Empty;
        [Column("person_id")]
        public string PersonId { get; set; } = string.Empty;
        [Column("person_name")]
        public string PersonName { get; set; } = string.Empty;
        [Column("role")]
        public CycleStaffRole Role { get; set; }
    }
}
