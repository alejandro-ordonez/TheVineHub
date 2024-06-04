using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.User.Dtos
{
    public class TokenResult
    {
        public string Message { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; } = false;
        public string Document { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
        public string Token { get; set; } = string.Empty;
    }
}
