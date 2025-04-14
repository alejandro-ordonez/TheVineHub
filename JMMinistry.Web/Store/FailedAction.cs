namespace JMMinistry.Web.Store
{
    public record FailedAction<TAction>
    {
        public string ErrorKey => typeof(TAction).Name;
    }
}
