using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Common.Dtos.Cell
{
    public class CellAttendanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }

        public IList<PartialUserInfoDto> Attendees { get; set; } = [];
        public IList<PartialUserInfoDto> MissingAttendees { get; set; } = [];

    }

    public class AddCellAttendanceDto
    {
        public IList<string> Disciples { get; set; } = [];
        public string? Notes { get; set; }
    }

    public class UpdateCellAttendanceDto
    {
        public IList<string> Disciples { get; set; } = [];
        public string? Notes { get; set; }
        public DateTime Date { get; set; }
    }
}
