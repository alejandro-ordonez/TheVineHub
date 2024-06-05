using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Domain
{
    public class PersonalInfoRole: IdentityUserRole<string>
    {
        public virtual PersonalInfo PersonalInfo { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
