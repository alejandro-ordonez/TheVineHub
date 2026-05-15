namespace JMMinistry.Common.Dtos.Cell;

public class AddDisciplesDto
{
    public string CellId { get; set; } = string.Empty;
    public IList<string> Documents { get; set; } = [];
}
