using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.StepDisciplesUseCase.Actions
{
    public record FetchEligibleDisciplesAction
    {
        public required int StepId { get; set; }
    }

    public record FetchEligibleDisciplesResultAction
    {
        public IList<StepDisciplesByCellDto> Groups { get; set; } = [];
    }
}
