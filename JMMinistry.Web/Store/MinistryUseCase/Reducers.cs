using Fluxor;
using JMMinistry.Web.Store.MinistryUseCase.Actions;

namespace JMMinistry.Web.Store.MinistryUseCase
{
    public static class Reducers
    {
        [ReducerMethod(typeof(FetchCellsAction))]
        public static MinistryState ReduceFetchCellsAction(MinistryState cellState) =>
            new(isLoading: true, cells: []);

        [ReducerMethod]
        public static MinistryState ReduceFetchCellsResultAction(MinistryState cellState, FetchCellsResultAction action) =>
            cellState with { IsLoading = false, Cells = action.Cells };


        [ReducerMethod(typeof(CreateCellAction))]
        public static MinistryState ReduceCreateCellAction(MinistryState cellState) =>
            cellState with { IsLoading = true };

        [ReducerMethod]
        public static MinistryState ReduceCreateCellResultAction(MinistryState cellState, CreateCellResultAction action) =>
            cellState with { IsLoading = false, Cells = [.. cellState.Cells, action.CellDto] };
    }
}
