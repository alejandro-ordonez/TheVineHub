using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellsUseCase.Actions
{
    public class CreateCellAction(CreateCellDto cell)
    {
        public CreateCellDto CellDto { get; } = cell;
    }

    public class CreateCellResultAction(CellDto cell)
    {
        public CellDto CellDto { get; } = cell;
    }
}
