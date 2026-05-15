namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CycleSessionDto
    {
        public string Id { get; set; } = string.Empty;
        public string StepCycleId { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public string? Topic { get; set; }
    }
}
