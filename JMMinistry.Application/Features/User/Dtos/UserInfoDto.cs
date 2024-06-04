using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Dtos
{
    public class UserInfoDto
    {
        public string Document { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Locality { get; set; } = null!;

        public string Neighborhood { get; set; } = null!;

        public string? Address { get; set; }

        public DateOnly Birthday { get; set; }
    }
}
