using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellUseCase.Actions
{
    public record FetchCellAction
    {
        public required int CellId { get; set; }
    }

    public record FetchCellResultAction
    {
        public required CellDto? Cell { get; set; }
    }
}
