namespace JMMinistry.Web.Store
{
    public record FailedAction<TAction>
    {
        public string ErrorKey { get; set; } = typeof(TAction).Name;
    }
}
