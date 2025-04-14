using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.DisciplesUseCase.Actions;

namespace JMMinistry.Web.Store.DisciplesUseCase
{
    public class Effects(IMinistryApi ministryApi)
    {
        [EffectMethod]
        public async Task HandleFetchDisciplesAction(FetchDisciplesAction action, IDispatcher dispatcher)
        {
            var result = await ministryApi.GetDisciples(action.CellId);

            if(result is null || !result.Success || result.Data is null)
                dispatcher.Dispatch(new FailedAction<FetchDisciplesAction>());

            dispatcher.Dispatch(new FetchDisciplesResultAction { Disciples = result?.Data ?? [] });
        }

        [EffectMethod]
        public async Task HandleAddDisciplesAction(AddDisciplesAction action, IDispatcher dispatcher)
        {
            var result = await ministryApi.AddDisciples(new AddDisciplesDto { CellId = action.CellId, Documents = action.Documents });

            if (result is null || !result.Success)
                dispatcher.Dispatch(new FailedAction<AddDisciplesAction>());

            dispatcher.Dispatch(new FetchDisciplesAction { CellId = action.CellId });
        }

        [EffectMethod]
        public async Task HandleRemoveDiscipleAction(RemoveDiscipleAction action, IDispatcher dispatcher)
        {
            var result = await ministryApi.RemoveDiscipleFromCell(action.CellId, action.DiscipleId);

            if (result is null || !result.Success)
                dispatcher.Dispatch(new FailedAction<AddDisciplesAction>());

            dispatcher.Dispatch(new FetchDisciplesAction { CellId = action.CellId });
        }
    }
}
