using JMMinistry.Common.Dtos.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.User
{
    public class UserInfoDto: PartialUserInfoDto
    {
        public string City { get; set; } = null!;

        public string? Locality { get; set; }

        public string Neighborhood { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;

        public DateOnly Birthday { get; set; }

        public MaritalStatus? MaritalStatus { get; set; }
        public EducationalLevel? EducationalLevel { get; set; }

        public AccessType AccessType { get; set; }

        public List<PartialUserInfoDto> Leaders { get; set; } = [];
    }
}
