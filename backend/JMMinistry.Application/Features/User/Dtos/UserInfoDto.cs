using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.User.Enums;
using System.Text.Json.Serialization;

namespace JMMinistry.Application.Features.User.Dtos;

public class UserInfoDto : BasicUserInfoDto
{
    [Column("city")]
    public string City { get; set; } = null!;
    [Column("locality")]
    public string? Locality { get; set; }
    [Column("neighborhood")]
    public string Neighborhood { get; set; } = null!;
    [Column("address")]
    public string Address { get; set; } = null!;
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;
    [Column("occupation")]
    public string Occupation { get; set; } = string.Empty;
    [Column("birthday")]
    public DateOnly? Birthday { get; set; }
    [Column("marital_status")]
    public MaritalStatus? MaritalStatus { get; set; }
    [Column("educational_level")]
    public EducationalLevel? EducationalLevel { get; set; }
    [Column("access_type")]
    public AccessType AccessType { get; set; }
}
