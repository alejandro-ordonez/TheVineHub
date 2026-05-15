using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain.Discipleship
{
    public partial class DiscipleshipNoteEntry
    {
        [Key]
        public int Id { get; set; }

        public required string Content { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public required int NoteId { get; set; }
        public DiscipleshipNote? Note { get; set; }

        public required string AuthorId { get; set; }
        public PersonalInfo? Author { get; set; }
    }
}
