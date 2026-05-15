using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain;

public partial class Event
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly EndDate { get; set; }

}
