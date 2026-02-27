using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.StepDisciplesUseCase.Actions
{
    public record FetchStepDisciplesAction
    {
        public required int StepId { get; set; }
    }

    public record FetchStepDisciplesResultAction
    {
        public required int StepId { get; set; }
        public IList<StepDisciplesByCellDto> Groups { get; set; } = [];
    }
}
