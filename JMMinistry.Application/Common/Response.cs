using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Common
{
    public class Response<T>
    {
        public string Details { get; set; } = string.Empty;
        public string[] Errors { get; set; } = [];
        public bool Success { get; set; } = false;
        public T? Data { get; set; }
    }
}
