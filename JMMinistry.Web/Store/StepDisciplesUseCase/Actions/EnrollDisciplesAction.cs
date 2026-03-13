using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Web.Store.StepDisciplesUseCase.Actions
{
    public record EnrollDisciplesAction
    {
        public required int StepId { get; set; }
        public required int CycleId { get; set; }
        public required IList<string> Documents { get; set; }
        public StepStatus? InitialStatus { get; set; }
    }

    public record EnrollDisciplesResultAction;
}
