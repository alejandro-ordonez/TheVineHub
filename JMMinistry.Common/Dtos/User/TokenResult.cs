using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.User
{
    public class TokenResult
    {
        public bool IsAuthenticated { get; set; } = false;
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
