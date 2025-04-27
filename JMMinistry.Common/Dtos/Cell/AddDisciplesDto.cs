namespace JMMinistry.Common.Dtos.Cell
{
    public class AddDisciplesDto
    {
        public int CellId { get; set; }
        public IList<string> Documents { get; set; } = [];
    }
}
