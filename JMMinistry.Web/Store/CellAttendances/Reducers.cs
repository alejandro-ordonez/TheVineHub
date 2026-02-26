using Fluxor;
using JMMinistry.Web.Store.CellAttendances.Actions;
using JMMinistry.Web.Store.CellUseCase;
using JMMinistry.Web.Store.CellUseCase.Actions;

namespace JMMinistry.Web.Store.CellAttendances
{
    public static class Reducers
    {
        [ReducerMethod(typeof(FetchCellAttendancesAction))]
        public static CellAttendancesState ReduceFetchCellAttendanceAction(CellAttendancesState state)
                    => state with { IsLoading = true };

        [ReducerMethod]
        public static CellAttendancesState ReduceFetchCellAttendanceResultAction(CellAttendancesState state, FetchCellAttendancesResultAction action)
                    => state with { IsLoading = false, Attendances = action.Attendances };

        [ReducerMethod(typeof(AddCellAttendanceAction))]
        public static CellAttendancesState ReduceAddCellAttendanceAction(CellAttendancesState state)
                    => state with { IsLoading = true };

        [ReducerMethod(typeof(UpdateCellAttendanceAction))]
        public static CellAttendancesState ReduceUpdateCellAttendanceAction(CellAttendancesState state)
                    => state with { IsLoading = true };
    }
}
