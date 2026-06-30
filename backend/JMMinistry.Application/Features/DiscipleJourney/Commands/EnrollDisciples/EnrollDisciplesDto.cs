using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples
{
    public class EnrollDisciplesDto
    {
        [Column("disciple_ids")]
        public IList<string> DiscipleIds { get; set; } = [];
        [Column("initial_status")]
        public StepStatus? InitialStatus { get; set; }
    }
}
