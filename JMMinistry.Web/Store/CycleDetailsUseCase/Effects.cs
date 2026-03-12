using Fluxor;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.CycleDetailsUseCase.Actions;

namespace JMMinistry.Web.Store.CycleDetailsUseCase
{
    public class Effects(IDiscipleJourneyApi api)
    {
        [EffectMethod]
        public async Task HandleFetchCycleDetailsAction(FetchCycleDetailsAction action, IDispatcher dispatcher)
        {
            var result = await api.GetCycleDetailsAsync(action.CycleId);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchCycleDetailsAction>());
                return;
            }

            dispatcher.Dispatch(new FetchCycleDetailsResultAction { Enrollments = result.Data });
        }

        [EffectMethod]
        public async Task HandleFetchCycleAttendanceAction(FetchCycleAttendanceAction action, IDispatcher dispatcher)
        {
            var result = await api.GetCycleAttendanceAsync(action.CycleId);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchCycleAttendanceAction>());
                return;
            }

            dispatcher.Dispatch(new FetchCycleAttendanceResultAction { Attendance = result.Data });
        }

        [EffectMethod]
        public async Task HandleFetchCycleSessionsAction(FetchCycleSessionsAction action, IDispatcher dispatcher)
        {
            var result = await api.GetCycleSessionsAsync(action.CycleId);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchCycleSessionsAction>());
                return;
            }

            dispatcher.Dispatch(new FetchCycleSessionsResultAction { Sessions = result.Data });
        }

        [EffectMethod]
        public async Task HandleCreateCycleSessionAction(CreateCycleSessionAction action, IDispatcher dispatcher)
        {
            var result = await api.CreateCycleSessionAsync(action.CycleId, action.Dto);

            if (result is null || !result.Success)
            {
                dispatcher.Dispatch(new FailedAction<CreateCycleSessionAction>());
                return;
            }

            dispatcher.Dispatch(new CreateCycleSessionResultAction());
            dispatcher.Dispatch(new FetchCycleSessionsAction { CycleId = action.CycleId });
            dispatcher.Dispatch(new FetchCycleAttendanceAction { CycleId = action.CycleId });
        }

        [EffectMethod]
        public async Task HandleDeleteCycleSessionAction(DeleteCycleSessionAction action, IDispatcher dispatcher)
        {
            var success = await api.DeleteCycleSessionAsync(action.CycleId, action.SessionId);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<DeleteCycleSessionAction>());
                return;
            }

            dispatcher.Dispatch(new DeleteCycleSessionResultAction());
            dispatcher.Dispatch(new FetchCycleSessionsAction { CycleId = action.CycleId });
            dispatcher.Dispatch(new FetchCycleAttendanceAction { CycleId = action.CycleId });
        }

        [EffectMethod]
        public async Task HandleFetchCycleStaffAction(FetchCycleStaffAction action, IDispatcher dispatcher)
        {
            var result = await api.GetCycleStaffAsync(action.CycleId);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchCycleStaffAction>());
                return;
            }

            dispatcher.Dispatch(new FetchCycleStaffResultAction { Staff = result.Data });
        }

        [EffectMethod]
        public async Task HandleAddCycleStaffAction(AddCycleStaffAction action, IDispatcher dispatcher)
        {
            var result = await api.AddCycleStaffAsync(action.CycleId, action.Dto);

            if (result is null || !result.Success)
            {
                dispatcher.Dispatch(new FailedAction<AddCycleStaffAction>());
                return;
            }

            dispatcher.Dispatch(new AddCycleStaffResultAction());
            dispatcher.Dispatch(new FetchCycleStaffAction { CycleId = action.CycleId });
            dispatcher.Dispatch(new FetchCycleDetailsAction { CycleId = action.CycleId });
        }

        [EffectMethod]
        public async Task HandleRemoveCycleStaffAction(RemoveCycleStaffAction action, IDispatcher dispatcher)
        {
            var success = await api.RemoveCycleStaffAsync(action.CycleId, action.StaffId);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<RemoveCycleStaffAction>());
                return;
            }

            dispatcher.Dispatch(new RemoveCycleStaffResultAction());
            dispatcher.Dispatch(new FetchCycleStaffAction { CycleId = action.CycleId });
            dispatcher.Dispatch(new FetchCycleDetailsAction { CycleId = action.CycleId });
        }

        [EffectMethod]
        public async Task HandleEnrollDisciplesAction(EnrollDisciplesAction action, IDispatcher dispatcher)
        {
            var success = await api.EnrollDisciplesAsync(action.CycleId, action.Dto);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<EnrollDisciplesAction>());
                return;
            }

            dispatcher.Dispatch(new EnrollDisciplesResultAction());
            dispatcher.Dispatch(new FetchCycleDetailsAction { CycleId = action.CycleId });
        }

        [EffectMethod]
        public async Task HandleUpdateEnrollmentStatusAction(UpdateEnrollmentStatusAction action, IDispatcher dispatcher)
        {
            var success = await api.UpdateEnrollmentStatusAsync(action.CycleId, action.EnrollmentId, action.Dto);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<UpdateEnrollmentStatusAction>());
                return;
            }

            dispatcher.Dispatch(new UpdateEnrollmentStatusResultAction());
            dispatcher.Dispatch(new FetchCycleDetailsAction { CycleId = action.CycleId });
        }

        [EffectMethod]
        public async Task HandleAssignGuideAction(AssignGuideAction action, IDispatcher dispatcher)
        {
            var success = await api.AssignGuideAsync(action.CycleId, action.Dto);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<AssignGuideAction>());
                return;
            }

            dispatcher.Dispatch(new AssignGuideResultAction());
            dispatcher.Dispatch(new FetchCycleDetailsAction { CycleId = action.CycleId });
        }

        [EffectMethod]
        public async Task HandleRecordCycleAttendanceAction(RecordCycleAttendanceAction action, IDispatcher dispatcher)
        {
            var success = await api.RecordCycleAttendanceAsync(action.CycleId, action.SessionId, action.Dto);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<RecordCycleAttendanceAction>());
                return;
            }

            dispatcher.Dispatch(new RecordCycleAttendanceResultAction());
            dispatcher.Dispatch(new FetchCycleAttendanceAction { CycleId = action.CycleId });
        }
    }
}
