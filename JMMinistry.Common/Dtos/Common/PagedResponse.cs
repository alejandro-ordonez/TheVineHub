using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Common
{
    public class PagedResponse<T>
    {
        public IList<T> Results { get; set; } = [];
        public int Total { get; set; } = 0;
        public int Page { get; set; } = 0;
    }
}
