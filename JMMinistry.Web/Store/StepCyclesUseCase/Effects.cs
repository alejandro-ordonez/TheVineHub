using Fluxor;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.StepCyclesUseCase.Actions;

namespace JMMinistry.Web.Store.StepCyclesUseCase
{
    public class Effects(IDiscipleJourneyApi api)
    {
        [EffectMethod]
        public async Task HandleFetchStepCyclesAction(FetchStepCyclesAction action, IDispatcher dispatcher)
        {
            var result = await api.GetStepCyclesAsync(action.StepId);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchStepCyclesAction>());
                return;
            }

            dispatcher.Dispatch(new FetchStepCyclesResultAction { Cycles = result.Data });
        }

        [EffectMethod]
        public async Task HandleCreateStepCycleAction(CreateStepCycleAction action, IDispatcher dispatcher)
        {
            var result = await api.CreateStepCycleAsync(action.StepId, action.Dto);

            if (result is null || !result.Success)
            {
                dispatcher.Dispatch(new FailedAction<CreateStepCycleAction>());
                return;
            }

            dispatcher.Dispatch(new CreateStepCycleResultAction());
            dispatcher.Dispatch(new FetchStepCyclesAction { StepId = action.StepId });
        }

        [EffectMethod]
        public async Task HandleUpdateStepCycleAction(UpdateStepCycleAction action, IDispatcher dispatcher)
        {
            var result = await api.UpdateStepCycleAsync(action.StepId, action.CycleId, action.Dto);

            if (result is null || !result.Success)
            {
                dispatcher.Dispatch(new FailedAction<UpdateStepCycleAction>());
                return;
            }

            dispatcher.Dispatch(new UpdateStepCycleResultAction());
            dispatcher.Dispatch(new FetchStepCyclesAction { StepId = action.StepId });
        }

        [EffectMethod]
        public async Task HandleDeleteStepCycleAction(DeleteStepCycleAction action, IDispatcher dispatcher)
        {
            var success = await api.DeleteStepCycleAsync(action.StepId, action.CycleId);

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<DeleteStepCycleAction>());
                return;
            }

            dispatcher.Dispatch(new DeleteStepCycleResultAction());
            dispatcher.Dispatch(new FetchStepCyclesAction { StepId = action.StepId });
        }
    }
}
