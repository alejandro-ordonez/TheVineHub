using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class Role: IdentityRole
{
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<PersonalInfoRole> UserRoles { get; set; } = [];
}
