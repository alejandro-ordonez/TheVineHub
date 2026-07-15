using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.Locations;

public class CityDto
{
    [Column("id")]
    public string Id { get; set; } = string.Empty;
    [Column("name")]
    public required string Name { get; set; }
    [Column("localities")]
    public IList<LocalityDto> Localities { get; set; } = [];
}

public class LocalityDto
{
    [Column("id")]
    public string Id { get; set; } = string.Empty;
    [Column("name")]
    public required string Name { get; set; }
}
