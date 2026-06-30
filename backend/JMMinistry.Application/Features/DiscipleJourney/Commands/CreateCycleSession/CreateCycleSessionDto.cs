using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession
{
    public class CreateCycleSessionDto
    {
        [Column("date")]
        public DateOnly Date { get; set; }
        [Column("topic")]
        public string? Topic { get; set; }
    }
}
