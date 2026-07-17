namespace TheVineHub.API.Common;

public class PagedResponse<T>
{
    public IList<T> Results { get; set; } = [];
    public int Total { get; set; } = 0;
    public int Page { get; set; } = 0;
}
