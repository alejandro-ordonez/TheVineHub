using Fluxor;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.StepDisciplesUseCase.Actions;

namespace JMMinistry.Web.Store.StepDisciplesUseCase
{
    public class Effects(IDiscipleJourneyApi discipleJourneyApi)
    {
        [EffectMethod]
        public async Task HandleUpdateStepCompletionAction(UpdateStepCompletionAction action, IDispatcher dispatcher)
        {
            var success = await discipleJourneyApi.UpdateStepCompletionAsync(action.StepId, action.DiscipleId, new UpdateStepCompletionDto
            {
                Status = action.Status,
                CompletionDate = action.CompletionDate
            });

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<UpdateStepCompletionAction>());
                return;
            }

            dispatcher.Dispatch(new UpdateStepCompletionResultAction());
            dispatcher.Dispatch(new FetchStepDisciplesAction { StepId = action.StepId });
        }

        [EffectMethod]
        public async Task HandleFetchStepDisciplesAction(FetchStepDisciplesAction action, IDispatcher dispatcher)
        {
            var result = await discipleJourneyApi.GetStepDisciplesAsync(action.StepId);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchStepDisciplesAction>());
                return;
            }

            dispatcher.Dispatch(new FetchStepDisciplesResultAction
            {
                StepId = action.StepId,
                Groups = result.Data
            });
        }

        [EffectMethod]
        public async Task HandleFetchEligibleDisciplesAction(FetchEligibleDisciplesAction action, IDispatcher dispatcher)
        {
            var result = await discipleJourneyApi.GetEligibleDisciplesAsync(action.StepId);

            if (result is null || !result.Success || result.Data is null)
            {
                dispatcher.Dispatch(new FailedAction<FetchEligibleDisciplesAction>());
                return;
            }

            dispatcher.Dispatch(new FetchEligibleDisciplesResultAction
            {
                Groups = result.Data
            });
        }

        [EffectMethod]
        public async Task HandleCompleteStepAction(CompleteStepAction action, IDispatcher dispatcher)
        {
            var success = await discipleJourneyApi.CompleteStepAsync(action.StepId, new CompleteStepDto
            {
                Documents = action.Documents,
                CompletionDate = action.CompletionDate
            });

            if (!success)
            {
                dispatcher.Dispatch(new FailedAction<CompleteStepAction>());
                return;
            }

            dispatcher.Dispatch(new CompleteStepResultAction());
            dispatcher.Dispatch(new FetchStepDisciplesAction { StepId = action.StepId });
        }
    }
}
