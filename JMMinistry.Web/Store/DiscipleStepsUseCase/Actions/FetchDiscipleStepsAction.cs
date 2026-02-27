using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.DiscipleStepsUseCase.Actions
{
    public record FetchDiscipleStepsAction;

    public record FetchDiscipleStepsResultAction
    {
        public IList<DiscipleStepDto> Steps { get; set; } = [];
    }

    public record CreateDiscipleStepAction
    {
        public required CreateDiscipleStepDto Step { get; set; }
    }

    public record CreateDiscipleStepResultAction
    {
        public required DiscipleStepDto Step { get; set; }
    }

    public record DeleteDiscipleStepAction
    {
        public required int StepId { get; set; }
    }

    public record DeleteDiscipleStepResultAction
    {
        public required int StepId { get; set; }
    }
}
