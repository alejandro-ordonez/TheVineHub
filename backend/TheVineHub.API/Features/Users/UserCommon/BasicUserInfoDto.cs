using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.Users;
using System.Text.Json.Serialization;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Users;

public class BasicUserInfoDto
{
    [Column("id")]
    public RecordId? Id { get; set; }
    [Column("full_name")]
    public string FullName { get; set; } = string.Empty;
    [Column("phone")]
    public string Phone { get; set; } = string.Empty;
    [Column("gender")]
    public Gender Gender { get; set; }
    [Column("photo_path")]
    public string? PhotoPath { get; set; }
}
