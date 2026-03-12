using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.StepCyclesUseCase.Actions
{
    public record FetchStepCyclesAction
    {
        public required int StepId { get; set; }
    }

    public record FetchStepCyclesResultAction
    {
        public IList<StepCycleDto> Cycles { get; set; } = [];
    }

    public record CreateStepCycleAction
    {
        public required int StepId { get; set; }
        public required CreateStepCycleDto Dto { get; set; }
    }

    public record CreateStepCycleResultAction;

    public record UpdateStepCycleAction
    {
        public required int StepId { get; set; }
        public required int CycleId { get; set; }
        public required UpdateStepCycleDto Dto { get; set; }
    }

    public record UpdateStepCycleResultAction;

    public record DeleteStepCycleAction
    {
        public required int StepId { get; set; }
        public required int CycleId { get; set; }
    }

    public record DeleteStepCycleResultAction;
}
