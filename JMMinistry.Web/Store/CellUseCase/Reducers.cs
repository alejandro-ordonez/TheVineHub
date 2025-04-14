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
    }
}
