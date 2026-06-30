using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff
{
    public class CreateCycleStaffDto
    {
        [Column("person_id")]
        public required string PersonId { get; set; }
        [Column("role")]
        public CycleStaffRole Role { get; set; }
    }
}
