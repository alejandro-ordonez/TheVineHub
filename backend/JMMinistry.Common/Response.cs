namespace JMMinistry.Common
{
    public class Response<T>
    {
        public string Details { get; set; } = string.Empty;
        public string[] Errors { get; set; } = [];
        public bool Success { get; set; } = false;
        public T? Data { get; set; }
        public int StatusCode { get; set; } = 200;
    }
}
