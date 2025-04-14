using Fluxor;
using JMMinistry.Web.Store.DisciplesUseCase.Actions;

namespace JMMinistry.Web.Store.DisciplesUseCase
{
    public static class Reducers
    {

        [ReducerMethod]
        public static DisciplesInCellState ReduceFetchDisciplesAction(DisciplesInCellState state, FetchDisciplesAction action) =>
            state with { IsLoading = true, Success = false, CellId = action.CellId };

        [ReducerMethod]
        public static DisciplesInCellState ReduceFetchDisciplesResult(DisciplesInCellState state, FetchDisciplesResultAction action) =>
            state with { IsLoading = false, Disciples = action.Disciples, Success = true };


        [ReducerMethod(typeof(AddDisciplesAction))]
        public static DisciplesInCellState ReduceAddDisciple(DisciplesInCellState state)
            => state with { IsLoading = true };

        [ReducerMethod(typeof(RemoveDiscipleAction))]
        public static DisciplesInCellState ReduceRemoveDisciple(DisciplesInCellState state)
            => state with { IsLoading = true };
    }
}
