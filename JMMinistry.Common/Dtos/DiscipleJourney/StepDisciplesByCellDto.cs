namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class StepDisciplesByCellDto
    {
        public int? CellId { get; set; }
        public string CellName { get; set; } = string.Empty;
        public string LeaderName { get; set; } = string.Empty;
        public IList<StepDiscipleDto> Disciples { get; set; } = [];
    }
}
