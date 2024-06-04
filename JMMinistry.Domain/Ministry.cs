using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JMMinistry.Domain;

public partial class Ministry: IdentityRole
{
    public int MinistryId { get; set; }
    public string Description { get; set; } = string.Empty;


    public ICollection<MinistryManagement> MinistryManagements { get; set; } = Array.Empty<MinistryManagement>();
}
