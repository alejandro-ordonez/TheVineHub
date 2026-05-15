using JMMinistry.Common.Dtos.Common;

namespace JMMinistry.Common.Dtos.User;

public class UsersSearchCriteria : PagedRequest
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Document { get; set; }
    public string? Requestor { get; set; }
}
