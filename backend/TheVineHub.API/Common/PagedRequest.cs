namespace TheVineHub.API.Common;

public class PagedRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public string? OrderByMember { get; set; }
    public string? OrderDirection { get; set; }
}
