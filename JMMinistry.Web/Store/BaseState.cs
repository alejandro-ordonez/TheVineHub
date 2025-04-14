namespace JMMinistry.Web.Store
{
    public record BaseState
    {
        public bool IsLoading { get; set; } = false;
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; } = [];
    }
}
