using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.StepDisciplesUseCase.Actions
{
    public record FetchActiveCyclesAction
    {
        public required int StepId { get; set; }
    }

    public record FetchActiveCyclesResultAction
    {
        public IList<StepCycleDto> Cycles { get; set; } = [];
    }
}
