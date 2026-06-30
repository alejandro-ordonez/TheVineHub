using JMMinistry.Application.Features.Location.Dtos;
using JMMinistry.Application.Common;

namespace JMMinistry.Application.Features.User.Dtos;

public class UsersSearchCriteria : PagedRequest
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Document { get; set; }
    public string? Requestor { get; set; }
}
