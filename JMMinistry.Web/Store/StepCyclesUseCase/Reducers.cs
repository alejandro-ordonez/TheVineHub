using Fluxor;
using JMMinistry.Web.Store.StepCyclesUseCase.Actions;

namespace JMMinistry.Web.Store.StepCyclesUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static StepCyclesState ReduceFetchStepCyclesAction(StepCyclesState state, FetchStepCyclesAction action) =>
            state with { IsLoading = true, CurrentStepId = action.StepId };

        [ReducerMethod]
        public static StepCyclesState ReduceFetchStepCyclesResultAction(StepCyclesState state, FetchStepCyclesResultAction action) =>
            state with { IsLoading = false, Cycles = action.Cycles, Success = true };

        [ReducerMethod(typeof(CreateStepCycleAction))]
        public static StepCyclesState ReduceCreateStepCycleAction(StepCyclesState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(CreateStepCycleResultAction))]
        public static StepCyclesState ReduceCreateStepCycleResultAction(StepCyclesState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(UpdateStepCycleAction))]
        public static StepCyclesState ReduceUpdateStepCycleAction(StepCyclesState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(UpdateStepCycleResultAction))]
        public static StepCyclesState ReduceUpdateStepCycleResultAction(StepCyclesState state) =>
            state with { IsLoading = false, Success = true };

        [ReducerMethod(typeof(DeleteStepCycleAction))]
        public static StepCyclesState ReduceDeleteStepCycleAction(StepCyclesState state) =>
            state with { IsLoading = true };

        [ReducerMethod(typeof(DeleteStepCycleResultAction))]
        public static StepCyclesState ReduceDeleteStepCycleResultAction(StepCyclesState state) =>
            state with { IsLoading = false, Success = true };
    }
}
