using Fluxor;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.CellUseCase.Actions;

namespace JMMinistry.Web.Store.CellUseCase
{
    public class Effects(IMinistryApi ministryApi)
    {

        [EffectMethod]
        public async Task HandleFetchCellAction(FetchCellAction action, IDispatcher dispatcher)
        {
            var response = await ministryApi.GetAsync(action.CellId);

            if (response is null || response.Data is null || !response.Success)
                dispatcher.Dispatch(new FailedAction<FetchCellAction>());

            dispatcher.Dispatch(new FetchCellResultAction { Cell = response?.Data });
        }

        [EffectMethod]
        public async Task HandleUpdateCellAction(UpdateCellAction action, IDispatcher dispatcher)
        {
            var response = await ministryApi.UpdateCellAsync(action.Cell);

            if (response is null || response.Data is null || !response.Success)
                dispatcher.Dispatch(new FailedAction<UpdateCellAction>());

            // Fetch the updated cell
            dispatcher.Dispatch(new FetchCellAction { CellId = action.Cell.Id!.Value });
        }
    }
}
