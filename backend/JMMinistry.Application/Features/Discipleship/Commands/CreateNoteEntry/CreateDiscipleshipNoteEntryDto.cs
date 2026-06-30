using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry
{
    public class CreateDiscipleshipNoteEntryDto
    {
        [Column("content")]
        public required string Content { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
