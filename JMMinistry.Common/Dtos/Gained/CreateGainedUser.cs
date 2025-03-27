using JMMinistry.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Gained
{
    public class CreateGainedUser: PartialUserInfoDto
    {
        public string Petition { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Locality { get; set; } = string.Empty;
    }
}
