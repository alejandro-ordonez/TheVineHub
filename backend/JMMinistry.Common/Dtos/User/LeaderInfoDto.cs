using System;
using System.Collections.Generic;
using System.Text;

namespace JMMinistry.Common.Dtos.User;

public class LeaderInfoDto
{
    public string? Id { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
}
