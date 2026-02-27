using Fluxor;
using JMMinistry.Web.Store.DiscipleStepsUseCase.Actions;

namespace JMMinistry.Web.Store.DiscipleStepsUseCase
{
    public static class Reducers
    {
        [ReducerMethod(typeof(FetchDiscipleStepsAction))]
        public static DiscipleStepsState ReduceFetchDiscipleStepsAction(DiscipleStepsState state) =>
            state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleStepsState ReduceFetchDiscipleStepsResultAction(DiscipleStepsState state, FetchDiscipleStepsResultAction action) =>
            state with { IsLoading = false, Steps = action.Steps, Success = true, LastFetched = DateTime.UtcNow };

        [ReducerMethod(typeof(CreateDiscipleStepAction))]
        public static DiscipleStepsState ReduceCreateDiscipleStepAction(DiscipleStepsState state) =>
            state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleStepsState ReduceCreateDiscipleStepResultAction(DiscipleStepsState state, CreateDiscipleStepResultAction action) =>
            state with { IsLoading = false, Steps = [.. state.Steps, action.Step], Success = true };

        [ReducerMethod(typeof(DeleteDiscipleStepAction))]
        public static DiscipleStepsState ReduceDeleteDiscipleStepAction(DiscipleStepsState state) =>
            state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleStepsState ReduceDeleteDiscipleStepResultAction(DiscipleStepsState state, DeleteDiscipleStepResultAction action) =>
            state with { IsLoading = false, Steps = state.Steps.Where(s => s.Id != action.StepId).ToList(), Success = true };
    }
}
