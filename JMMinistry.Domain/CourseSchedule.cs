using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Domain
{
    public class CourseSchedule
    {
        public int Id { get; set; }

        public required int CourseId { get; set; }
        public Course? Course { get; set; }

        public required DayOfWeek Day { get; set; }
        public required TimeOnly Start { get; set; }
        public required TimeOnly End { get; set; }


        public IList<PersonalInfo> Students { get; set; } = [];
    }
}
