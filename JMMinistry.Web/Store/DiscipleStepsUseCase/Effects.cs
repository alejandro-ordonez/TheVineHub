using Fluxor;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.DiscipleStepsUseCase.Actions;

namespace JMMinistry.Web.Store.DiscipleStepsUseCase
{
    public class Effects(IDiscipleJourneyApi discipleJourneyApi)
    {
        [EffectMethod]
        public async Task HandleFetchDiscipleStepsAction(FetchDiscipleStepsAction action, IDispatcher dispatcher)
        {
            var result = await discipleJourneyApi.GetStepsAsync();

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchDiscipleStepsAction>());
                return;
            }

            dispatcher.Dispatch(new FetchDiscipleStepsResultAction { Steps = result.Data });
        }

        [EffectMethod]
        public async Task HandleCreateDiscipleStepAction(CreateDiscipleStepAction action, IDispatcher dispatcher)
        {
            var result = await discipleJourneyApi.CreateStepAsync(action.Step);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<CreateDiscipleStepAction>());
                return;
            }

            dispatcher.Dispatch(new CreateDiscipleStepResultAction { Step = result.Data });
            dispatcher.Dispatch(new FetchDiscipleStepsAction());
        }

        [EffectMethod]
        public async Task HandleDeleteDiscipleStepAction(DeleteDiscipleStepAction action, IDispatcher dispatcher)
        {
            var success = await discipleJourneyApi.DeleteStepAsync(action.StepId);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<DeleteDiscipleStepAction>());
                return;
            }

            dispatcher.Dispatch(new DeleteDiscipleStepResultAction { StepId = action.StepId });
            dispatcher.Dispatch(new FetchDiscipleStepsAction());
        }

        [EffectMethod]
        public async Task HandleUpdateDiscipleStepAction(UpdateDiscipleStepAction action, IDispatcher dispatcher)
        {
            var result = await discipleJourneyApi.UpdateStepAsync(action.Step.Id, action.Step);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<UpdateDiscipleStepAction>());
                return;
            }

            dispatcher.Dispatch(new UpdateDiscipleStepResultAction { Step = result.Data });
            dispatcher.Dispatch(new FetchDiscipleStepsAction());
        }
    }
}
