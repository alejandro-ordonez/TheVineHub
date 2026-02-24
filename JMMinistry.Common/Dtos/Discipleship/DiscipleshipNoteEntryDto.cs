namespace JMMinistry.Common.Dtos.Discipleship
{
    public class DiscipleshipNoteEntryDto
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NoteId { get; set; }
        public required string AuthorId { get; set; }
    }
}
