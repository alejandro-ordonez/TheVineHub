using Fluxor;
using JMMinistry.Web.Store.StepDisciplesUseCase.Actions;

namespace JMMinistry.Web.Store.StepDisciplesUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static StepDisciplesState ReduceFetchStepDisciplesAction(StepDisciplesState state, FetchStepDisciplesAction action) =>
            state with { IsLoading = true, StepId = action.StepId };

        [ReducerMethod]
        public static StepDisciplesState ReduceFetchStepDisciplesResultAction(StepDisciplesState state, FetchStepDisciplesResultAction action) =>
            state with { IsLoading = false, StepId = action.StepId, Groups = action.Groups, Success = true };

        [ReducerMethod]
        public static StepDisciplesState ReduceFetchEligibleDisciplesAction(StepDisciplesState state, FetchEligibleDisciplesAction action) =>
            state with { IsLoadingEligible = true };

        [ReducerMethod]
        public static StepDisciplesState ReduceFetchEligibleDisciplesResultAction(StepDisciplesState state, FetchEligibleDisciplesResultAction action) =>
            state with { IsLoadingEligible = false, EligibleGroups = action.Groups };

        [ReducerMethod]
        public static StepDisciplesState ReduceCompleteStepAction(StepDisciplesState state, CompleteStepAction action) =>
            state with { IsCompletingStep = true };

        [ReducerMethod]
        public static StepDisciplesState ReduceCompleteStepResultAction(StepDisciplesState state, CompleteStepResultAction action) =>
            state with { IsCompletingStep = false };

        [ReducerMethod(typeof(FetchActiveCyclesAction))]
        public static StepDisciplesState ReduceFetchActiveCyclesAction(StepDisciplesState state) =>
            state with { IsLoadingActiveCycles = true };

        [ReducerMethod]
        public static StepDisciplesState ReduceFetchActiveCyclesResultAction(StepDisciplesState state, FetchActiveCyclesResultAction action) =>
            state with { IsLoadingActiveCycles = false, ActiveCycles = action.Cycles };

        [ReducerMethod(typeof(EnrollDisciplesAction))]
        public static StepDisciplesState ReduceEnrollDisciplesAction(StepDisciplesState state) =>
            state with { IsCompletingStep = true };

        [ReducerMethod(typeof(EnrollDisciplesResultAction))]
        public static StepDisciplesState ReduceEnrollDisciplesResultAction(StepDisciplesState state) =>
            state with { IsCompletingStep = false };

        [ReducerMethod]
        public static StepDisciplesState ReduceUpdateStepCompletionAction(StepDisciplesState state, UpdateStepCompletionAction action) =>
            state with { IsUpdatingCompletion = true };

        [ReducerMethod]
        public static StepDisciplesState ReduceUpdateStepCompletionResultAction(StepDisciplesState state, UpdateStepCompletionResultAction action) =>
            state with { IsUpdatingCompletion = false };
    }
}
