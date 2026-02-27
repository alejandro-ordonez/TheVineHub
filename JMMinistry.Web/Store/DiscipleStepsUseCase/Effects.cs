using Fluxor;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.DiscipleStepsUseCase.Actions;

namespace JMMinistry.Web.Store.DiscipleStepsUseCase
{
    public class Effects(IDiscipleJourneyApi discipleJourneyApi, IState<DiscipleStepsState> state)
    {
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(15);

        [EffectMethod]
        public async Task HandleFetchDiscipleStepsAction(FetchDiscipleStepsAction action, IDispatcher dispatcher)
        {
            if (state.Value.LastFetched is not null
                && DateTime.UtcNow - state.Value.LastFetched.Value < CacheDuration)
            {
                dispatcher.Dispatch(new FetchDiscipleStepsResultAction { Steps = state.Value.Steps });
                return;
            }

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
        }
    }
}
