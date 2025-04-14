using JMMinistry.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Cell
{
    public class CellAttendanceDto
    {
        public DateTime Date { get; set; }
        public int AttendantCount { get; set; }

        public IList<PartialUserInfoDto> Attendees { get; set; } = [];

    }
}
