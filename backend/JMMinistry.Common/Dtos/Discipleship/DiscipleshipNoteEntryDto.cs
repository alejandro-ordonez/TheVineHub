namespace JMMinistry.Common.Dtos.Discipleship
{
    public class DiscipleshipNoteEntryDto
    {
        public string Id { get; set; } = string.Empty;
        public required string Content { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public string NoteId { get; set; } = string.Empty;
        public required string AuthorId { get; set; }
    }
}
