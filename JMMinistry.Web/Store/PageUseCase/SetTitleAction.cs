namespace JMMinistry.Web.Store.PageUseCase
{
    public record SetTitleAction
    {
        public required string Title { get; set; }
    }
}
