namespace JMMinistry.Common.Dtos.Discipleship
{
    public class DiscipleshipNoteDto
    {
        public int NoteId { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public NoteStatus NoteStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Categories { get; set; } = [];

        public required string DiscipleId { get; set; }
        public required string LeaderId { get; set; }

        public IList<DiscipleshipNoteEntryDto> Entries { get; set; } = [];
    }
}
