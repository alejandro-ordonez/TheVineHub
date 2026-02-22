namespace JMMinistry.Common.Dtos.User
{
    public class CreateUserInfoDto : UserInfoDto
    {
        public string? Password { get; set; }
        public bool IsUpdate { get; set; }
    }
}
