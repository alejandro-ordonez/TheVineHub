using Fluxor;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.MinistryUseCase.Actions;

namespace JMMinistry.Web.Store.MinistryUseCase
{
    public class Effects(IMinistryApi ministryApi)
    {
        [EffectMethod(typeof(FetchCellsAction))]
        public async Task HandleFetchCellsAction(IDispatcher dispatcher)
        {
            var response = await ministryApi.GetAsync();

            if (response is null || response.Data is null || !response.Success)
                dispatcher.Dispatch(new FailedAction<FetchCellsAction>());

            dispatcher.Dispatch(new FetchCellsResultAction { Cells = response?.Data ?? [] });
        }

        [EffectMethod]
        public async Task HandleCreateCellAction(CreateCellAction action, IDispatcher dispatcher)
        {
            var response = await ministryApi.CreateCell(action.CellDto);

            if (response is null || response.Data is null || !response.Success)
                dispatcher.Dispatch(new FailedAction<CreateCellAction>());

            dispatcher.Dispatch(new FetchCellsAction());
        }
    }
}
