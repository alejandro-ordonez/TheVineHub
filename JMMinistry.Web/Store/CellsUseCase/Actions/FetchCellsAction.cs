using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellsUseCase.Actions
{
    public partial record FetchCellsAction
    {
    }

    public record FetchCellsResultAction
    {
        public IList<CellDto> Cells { get; set; } = [];
    }
}
