using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Common.Dtos.Cell;

public class CellDto
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool MainCell { get; set; }
    public string Address { get; set; } = string.Empty;
    public int Level { get; set; } = 1;
    public int MemberCount { get; set; } = 0;
    public DayOfWeek? Day { get; set; }
    public DateOnly? OpeningDate { get; set; }

    public IEnumerable<LeaderInfoDto> Leaders { get; set; } = [];
}
