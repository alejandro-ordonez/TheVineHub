using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.DiscipleJourney.Dtos
{
    public class StepDisciplesByCellDto
    {
        [Column("cell_id")]
        public string? CellId { get; set; }
        [Column("cell_name")]
        public string CellName { get; set; } = string.Empty;
        [Column("leader_name")]
        public string LeaderName { get; set; } = string.Empty;
        [Column("disciples")]
        public IList<StepDiscipleDto> Disciples { get; set; } = [];
    }
}
