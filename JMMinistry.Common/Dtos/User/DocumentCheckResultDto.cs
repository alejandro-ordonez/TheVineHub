namespace JMMinistry.Common.Dtos.User
{
    public class DocumentCheckResultDto
    {
        public bool Exists { get; set; }
        public bool HasCell { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
}
