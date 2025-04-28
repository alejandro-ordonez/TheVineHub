using Fluxor;
using JMMinistry.Web.Store.CellAttendances.Actions;
using JMMinistry.Web.Store.CellUseCase;
using JMMinistry.Web.Store.CellUseCase.Actions;

namespace JMMinistry.Web.Store.CellAttendances
{
    public static class Reducers
    {
        public static CellAttendancesState ReduceFetchCellAttendanceAction(CellAttendancesState state, FetchCellAttendancesAction action)
                    => state with { IsLoading = true };

        public static CellAttendancesState ReduceFetchCellAttendanceResultAction(CellAttendancesState state, FetchCellAttendancesResultAction action)
                    => state with { IsLoading = false, Attendances = action.Attendances };

        [ReducerMethod(typeof(AddCellAttendanceAction))]
        public static CellAttendancesState ReduceAddCellAttendanceAction(CellAttendancesState state)
                    => state with { IsLoading = true };
    }
}
