using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.Discipleship;
namespace TheVineHub.API.Features.Discipleship
{
    public class DiscipleshipNoteDto
    {
        [Column("note_id")]
        public string NoteId { get; set; } = string.Empty;
        [Column("title")]
        public required string Title { get; set; }
        [Column("description")]
        public string Description { get; set; } = string.Empty;
        [Column("note_status")]
        public NoteStatus NoteStatus { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("categories")]
        public List<string> Categories { get; set; } = [];

        [Column("disciple_id")]

        public required string DiscipleId { get; set; }
        [Column("leader_id")]
        public required string LeaderId { get; set; }

        [Column("entries")]

        public IList<DiscipleshipNoteEntryDto> Entries { get; set; } = [];
    }
}
