using Fluxor;
using JMMinistry.Web.Store.CycleDetailsUseCase.Actions;

namespace JMMinistry.Web.Store.CycleDetailsUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static CycleDetailsState ReduceFetchCycleDetailsAction(CycleDetailsState state, FetchCycleDetailsAction action) =>
            state with { IsLoading = true, CurrentCycleId = action.CycleId };

        [ReducerMethod]
        public static CycleDetailsState ReduceFetchCycleDetailsResultAction(CycleDetailsState state, FetchCycleDetailsResultAction action) =>
            state with { IsLoading = false, Enrollments = action.Enrollments, Success = true };

        [ReducerMethod(typeof(FetchCycleSessionsAction))]
        public static CycleDetailsState ReduceFetchCycleSessionsAction(CycleDetailsState state) =>
            state with { IsLoadingSessions = true };

        [ReducerMethod]
        public static CycleDetailsState ReduceFetchCycleSessionsResultAction(CycleDetailsState state, FetchCycleSessionsResultAction action) =>
            state with { IsLoadingSessions = false, Sessions = action.Sessions, Success = true };

        [ReducerMethod(typeof(FetchCycleAttendanceAction))]
        public static CycleDetailsState ReduceFetchCycleAttendanceAction(CycleDetailsState state) =>
            state with { IsLoadingAttendance = true };

        [ReducerMethod]
        public static CycleDetailsState ReduceFetchCycleAttendanceResultAction(CycleDetailsState state, FetchCycleAttendanceResultAction action) =>
            state with { IsLoadingAttendance = false, Attendance = action.Attendance, Success = true };

        [ReducerMethod(typeof(CreateCycleSessionAction))]
        public static CycleDetailsState ReduceCreateCycleSessionAction(CycleDetailsState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(CreateCycleSessionResultAction))]
        public static CycleDetailsState ReduceCreateCycleSessionResultAction(CycleDetailsState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(DeleteCycleSessionAction))]
        public static CycleDetailsState ReduceDeleteCycleSessionAction(CycleDetailsState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(DeleteCycleSessionResultAction))]
        public static CycleDetailsState ReduceDeleteCycleSessionResultAction(CycleDetailsState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(FetchCycleStaffAction))]
        public static CycleDetailsState ReduceFetchCycleStaffAction(CycleDetailsState state) =>
            state with { IsLoadingStaff = true };

        [ReducerMethod]
        public static CycleDetailsState ReduceFetchCycleStaffResultAction(CycleDetailsState state, FetchCycleStaffResultAction action) =>
            state with { IsLoadingStaff = false, Staff = action.Staff, Success = true };

        [ReducerMethod(typeof(AddCycleStaffAction))]
        public static CycleDetailsState ReduceAddCycleStaffAction(CycleDetailsState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(AddCycleStaffResultAction))]
        public static CycleDetailsState ReduceAddCycleStaffResultAction(CycleDetailsState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(RemoveCycleStaffAction))]
        public static CycleDetailsState ReduceRemoveCycleStaffAction(CycleDetailsState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(RemoveCycleStaffResultAction))]
        public static CycleDetailsState ReduceRemoveCycleStaffResultAction(CycleDetailsState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(EnrollDisciplesAction))]
        public static CycleDetailsState ReduceEnrollDisciplesAction(CycleDetailsState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(EnrollDisciplesResultAction))]
        public static CycleDetailsState ReduceEnrollDisciplesResultAction(CycleDetailsState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(UpdateEnrollmentStatusAction))]
        public static CycleDetailsState ReduceUpdateEnrollmentStatusAction(CycleDetailsState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(UpdateEnrollmentStatusResultAction))]
        public static CycleDetailsState ReduceUpdateEnrollmentStatusResultAction(CycleDetailsState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(AssignGuideAction))]
        public static CycleDetailsState ReduceAssignGuideAction(CycleDetailsState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(AssignGuideResultAction))]
        public static CycleDetailsState ReduceAssignGuideResultAction(CycleDetailsState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(RecordCycleAttendanceAction))]
        public static CycleDetailsState ReduceRecordCycleAttendanceAction(CycleDetailsState state) =>
            state with { IsLoadingAttendance = true };

        [ReducerMethod(typeof(RecordCycleAttendanceResultAction))]
        public static CycleDetailsState ReduceRecordCycleAttendanceResultAction(CycleDetailsState state) =>
            state with { IsLoadingAttendance = false, Success = true };
    }
}
