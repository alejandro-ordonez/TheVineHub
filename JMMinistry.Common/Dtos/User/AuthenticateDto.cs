using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.User
{
    public class AuthenticateDto
    {
        public string Document { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
