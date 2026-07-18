using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.Users;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Cells;

public class CellDto
{
    [Column("id")]
    public RecordId? Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    [Column("main_cell")]
    public bool MainCell { get; set; }
    [Column("address")]
    public string Address { get; set; } = string.Empty;
    [Column("level")]
    public int Level { get; set; } = 1;
    [Column("member_count")]
    public int MemberCount { get; set; } = 0;
    [Column("day")]
    public DayOfWeek? Day { get; set; }
    [Column("opening_date")]
    public DateOnly? OpeningDate { get; set; }
    [Column("leaders")]
    public IEnumerable<LeaderInfoDto> Leaders { get; set; } = [];
    [Column("parent_cell_id")]
    public string? ParentCellId { get; set; }
}
