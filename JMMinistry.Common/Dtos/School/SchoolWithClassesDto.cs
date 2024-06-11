using JMMinistry.Common.Dtos.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.School
{
    public class SchoolWithClassesDto : SchoolDto
    {
        public ICollection<ClassDto> Classes { get; set; } = [];
    }
}
