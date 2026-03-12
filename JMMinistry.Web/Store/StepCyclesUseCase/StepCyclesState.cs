using Fluxor;
using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.StepCyclesUseCase
{
    [FeatureState]
    public record StepCyclesState : BaseState
    {
        public IList<StepCycleDto> Cycles { get; set; } = [];
        public int? CurrentStepId { get; set; }
    }
}
