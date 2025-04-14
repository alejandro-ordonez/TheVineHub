namespace JMMinistry.Web.Store.DisciplesUseCase.Actions
{
    public record RemoveDiscipleAction
    {
        public required int CellId { get; set; }
        public required string DiscipleId { get; set; }
    }
}
