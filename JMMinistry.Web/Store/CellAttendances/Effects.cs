using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.CellAttendances.Actions;
using JMMinistry.Web.Store.CellUseCase.Actions;

namespace JMMinistry.Web.Store.CellAttendances
{
    public class Effects(IMinistryApi ministryApi)
    {
        [EffectMethod]
        public async Task HandleFetchCellAttendanceAction(FetchCellAttendancesAction action, IDispatcher dispatcher)
        {
            var response = await ministryApi.GetCellAttendances(action.CellId);

            if (response is null || response.Data is null || !response.Success)
            {
                dispatcher.Dispatch(new FailedAction<FetchCellAttendancesAction>());
                return;
            }

            dispatcher.Dispatch(new FetchCellAttendancesResultAction { Attendances = response.Data });
        }


        [EffectMethod]
        public async Task HandleAddCellAttendanceAction(AddCellAttendanceAction action, IDispatcher dispatcher)
        {
            var response = await ministryApi.RecordCellAttendance(action.CellId, new AddCellAttendanceDto { Disciples = action.Documents, Notes = action.Notes });

            if (response is null || response.Data is null || !response.Success)
                dispatcher.Dispatch(new FailedAction<AddCellAttendanceAction>());

            dispatcher.Dispatch(new FetchCellAttendancesAction { CellId = action.CellId });
        }
    }
}
