namespace JMMinistry.Web.Store.StepDisciplesUseCase.Actions
{
    public record CompleteStepAction
    {
        public required int StepId { get; set; }
        public required IList<string> Documents { get; set; }
        public required DateOnly CompletionDate { get; set; }
    }

    public record CompleteStepResultAction;
}
