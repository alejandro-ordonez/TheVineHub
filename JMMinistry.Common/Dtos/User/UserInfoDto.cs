using JMMinistry.Common.Dtos.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.User
{
    public class UserInfoDto
    {
        public string Document { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Locality { get; set; } = null!;

        public string Neighborhood { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateOnly Birthday { get; set; }

        public MinistryStatus MinistryStatus { get; set; }

        public Gender Gender { get; set; }
    }
}
