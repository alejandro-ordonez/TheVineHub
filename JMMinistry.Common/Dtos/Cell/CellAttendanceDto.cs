using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Common.Dtos.Cell
{
    public class CellAttendanceDto
    {
        public DateTime Date { get; set; }
        public int AttendantCount { get; set; }

        public IList<PartialUserInfoDto> Attendees { get; set; } = [];

    }
}
