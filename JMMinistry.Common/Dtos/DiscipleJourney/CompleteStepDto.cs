namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CompleteStepDto
    {
        public IList<string> Documents { get; set; } = [];
        public DateOnly CompletionDate { get; set; }
    }
}
