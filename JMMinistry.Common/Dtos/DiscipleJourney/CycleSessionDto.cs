namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CycleSessionDto
    {
        public int Id { get; set; }
        public int StepCycleId { get; set; }
        public DateOnly Date { get; set; }
        public string? Topic { get; set; }
    }
}
