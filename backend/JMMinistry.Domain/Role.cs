using Microsoft.AspNetCore.Identity;

namespace JMMinistry.Domain;

public partial class Role : IdentityRole
{
    public string Description { get; set; } = string.Empty;

    public virtual IList<PersonalInfoRole> UserRoles { get; set; } = [];
}
