using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.MinistryUseCase.Actions
{
    public class CreateCellAction(CellDto cell)
    {
        public CellDto CellDto { get; } = cell;
    }

    public class CreateCellResultAction(CellDto cell)
    {
        public CellDto CellDto { get; } = cell;
    }
}
