using Microsoft.AspNetCore.Identity;

namespace JMMinistry.Domain
{
    public class PersonalInfoRole : IdentityUserRole<string>
    {
        public virtual PersonalInfo PersonalInfo { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
