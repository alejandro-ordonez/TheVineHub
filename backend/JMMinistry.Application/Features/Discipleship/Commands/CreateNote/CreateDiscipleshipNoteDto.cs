using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNote
{
    public class CreateDiscipleshipNoteDto
    {
        [Column("title")]
        public required string Title { get; set; }
        [Column("description")]
        public string Description { get; set; } = string.Empty;
        [Column("categories")]
        public List<string> Categories { get; set; } = [];
    }
}
