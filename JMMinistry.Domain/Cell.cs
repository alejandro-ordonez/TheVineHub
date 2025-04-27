using JMMinistry.Domain.Location;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public partial class Cell
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool MainCell { get; set; }

    public int CityId { get; set; }
    public City? City { get; set; }

    public int LocalityId { get; set; }
    public Locality? Locality { get; set; }

    public required string Address { get; set; }
    public required DayOfWeek? Day { get; set; }

    [MaxLength(2)]
    public IList<PersonalInfo> Leaders { get; set; } = [];
    public IList<PersonalInfo> Disciples { get; set; } = [];
}
