using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.Discipleship.Dtos
{
    public class DiscipleshipNoteEntryDto
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;
        [Column("content")]
        public required string Content { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("note_id")]
        public string NoteId { get; set; } = string.Empty;
        [Column("author_id")]
        public required string AuthorId { get; set; }
    }
}
