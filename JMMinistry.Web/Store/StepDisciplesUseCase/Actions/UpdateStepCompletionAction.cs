using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Web.Store.StepDisciplesUseCase.Actions
{
    public record UpdateStepCompletionAction
    {
        public required int StepId { get; set; }
        public required string DiscipleId { get; set; }
        public required StepStatus Status { get; set; }
        public DateOnly? CompletionDate { get; set; }
    }

    public record UpdateStepCompletionResultAction;
}
