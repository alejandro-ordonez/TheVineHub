using Fluxor;
using JMMinistry.Web.Store.CellUseCase.Actions;

namespace JMMinistry.Web.Store.CellUseCase
{
    public static class Reducers
    {

        [ReducerMethod(typeof(FetchCellAction))]
        public static CellState ReduceFetchCellAction(CellState state)
            => state with { IsLoading = true };

        [ReducerMethod]
        public static CellState ReduceFetchCellResultAction(CellState state, FetchCellResultAction action)
            => state with { IsLoading = false, Cell = action.Cell };

        [ReducerMethod(typeof(ResetCellAction))]
        public static CellState ReduceResetCellAction(CellState state)
            => state with { IsLoading = false, Cell = new Common.Dtos.Cell.CellDto() };

        [ReducerMethod(typeof(UpdateCellAction))]
        public static CellState ReduceUpdateCellAction(CellState state)
            => state with { IsLoading = true };
    }
}
