namespace JMMinistry.Common.Dtos.Discipleship
{
    public class CreateDiscipleshipNoteDto
    {
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = [];
    }
}
