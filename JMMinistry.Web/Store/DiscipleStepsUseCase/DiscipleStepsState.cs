using Fluxor;
using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.DiscipleStepsUseCase
{
    [FeatureState]
    public record DiscipleStepsState : BaseState
    {
        public IList<DiscipleStepDto> Steps { get; set; } = [];
        public DateTime? LastFetched { get; set; }
    }
}
