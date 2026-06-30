using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.DiscipleJourney.Dtos
{
    public class CycleSessionDto
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;
        [Column("step_cycle_id")]
        public string StepCycleId { get; set; } = string.Empty;
        [Column("date")]
        public DateOnly Date { get; set; }
        [Column("topic")]
        public string? Topic { get; set; }
    }
}
