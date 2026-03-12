using Fluxor;
using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.StepDisciplesUseCase
{
    [FeatureState]
    public record StepDisciplesState : BaseState
    {
        public int StepId { get; set; }
        public IList<StepDisciplesByCellDto> Groups { get; set; } = [];
        public IList<StepDisciplesByCellDto> EligibleGroups { get; set; } = [];
        public IList<StepCycleDto> ActiveCycles { get; set; } = [];
        public bool IsLoadingEligible { get; set; }
        public bool IsLoadingActiveCycles { get; set; }
        public bool IsCompletingStep { get; set; }
        public bool IsUpdatingCompletion { get; set; }
    }
}
