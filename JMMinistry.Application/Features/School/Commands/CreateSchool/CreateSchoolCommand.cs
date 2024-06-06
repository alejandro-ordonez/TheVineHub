using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.School.Commands.CreateSchool
{
    public class CreateSchoolCommand
    {
        public string SchoolName { get; set; } = null!;

        public string SchoolDescription { get; set; } = null!;

    }
}
