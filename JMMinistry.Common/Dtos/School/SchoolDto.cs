using JMMinistry.Common.Dtos.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.School
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string SchoolName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
