using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellUseCase.Actions
{
    public record UpdateCellAction
    {
        public required CellDto Cell { get; set; }
    }
}
