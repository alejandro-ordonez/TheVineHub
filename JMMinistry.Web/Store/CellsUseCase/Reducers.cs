using Fluxor;
using JMMinistry.Web.Store.CellsUseCase.Actions;

namespace JMMinistry.Web.Store.CellsUseCase
{
    public static class Reducers
    {
        [ReducerMethod(typeof(FetchCellsAction))]
        public static CellsState ReduceFetchCellsAction(CellsState cellState) =>
            new(isLoading: true, cells: []);

        [ReducerMethod]
        public static CellsState ReduceFetchCellsResultAction(CellsState cellState, FetchCellsResultAction action) =>
            cellState with { IsLoading = false, Cells = action.Cells };


        [ReducerMethod(typeof(CreateCellAction))]
        public static CellsState ReduceCreateCellAction(CellsState cellState) =>
            cellState with { IsLoading = true };        

        [ReducerMethod]
        public static CellsState ReduceCreateCellResultAction(CellsState cellState, CreateCellResultAction action) =>
            cellState with { IsLoading = false, Cells = [.. cellState.Cells, action.CellDto] };
    }
}
