using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.User.Dtos;
namespace JMMinistry.Application.Features.User.Commands.CreateUser;

public class CreateUserInfoDto : UserInfoDto
{
    [Column("name")]
    public required string Name { get; set; }
    [Column("last_name")]
    public required string LastName { get; set; }
    [Column("password")]
    public string? Password { get; set; }
    [Column("is_update")]
    public bool IsUpdate { get; set; }
}
