using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.User.Dtos;

public class DocumentCheckResultDto
{
    [Column("exists")]
    public bool Exists { get; set; }
    [Column("has_cell")]
    public bool HasCell { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("last_name")]
    public string? LastName { get; set; }
}
