using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples;

public class AddDisciplesDto
{
    [Column("cell_id")]
    public string CellId { get; set; } = string.Empty;
    [Column("documents")]
    public IList<string> Documents { get; set; } = [];
}
