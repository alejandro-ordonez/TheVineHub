using JMMinistry.Common.Dtos.User.Enums;
using System.Text.Json.Serialization;

namespace JMMinistry.Common.Dtos.User;

public class BasicUserInfoDto
{
    public string? Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string? PhotoPath { get; set; }
}
