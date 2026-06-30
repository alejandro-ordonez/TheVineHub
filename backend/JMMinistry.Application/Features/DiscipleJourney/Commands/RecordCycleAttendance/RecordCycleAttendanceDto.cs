using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance
{
    public class RecordCycleAttendanceDto
    {
        [Column("disciple_ids")]
        public IList<string> DiscipleIds { get; set; } = [];
    }
}
