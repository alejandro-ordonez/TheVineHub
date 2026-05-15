namespace JMMinistry.Common.Dtos.User;

public class CreateUserInfoDto : UserInfoDto
{
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public string? Password { get; set; }
    public bool IsUpdate { get; set; }
}
