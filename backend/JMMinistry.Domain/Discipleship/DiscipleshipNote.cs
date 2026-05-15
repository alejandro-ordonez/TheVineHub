using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain.Discipleship
{
    public partial class DiscipleshipNote
    {
        [Key]
        public int Id { get; set; }

        public required string Title { get; set; }

        public string Description { get; set; } = string.Empty;
        
        public NoteStatus Status { get; set; }

        public string Categories { get; set; } = "[]";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public required string DiscipleId { get; set; }
        public PersonalInfo? Disciple { get; set; }

        public required string LeaderId { get; set; }
        public PersonalInfo? Leader { get; set; }

        public IList<DiscipleshipNoteEntry> Entries { get; set; } = [];
    }
}
