using TheVineHub.API.Features.Locations;
using TheVineHub.API.Common;

namespace TheVineHub.API.Features.Users;

public class UsersSearchCriteria : PagedRequest
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Document { get; set; }
    public string? Requestor { get; set; }
}
