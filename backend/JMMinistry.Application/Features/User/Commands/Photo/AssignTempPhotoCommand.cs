using System.ComponentModel.DataAnnotations.Schema;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class AssignTempPhotoCommand : ICommand<string>
{
    [Column("requestor_id")]
    public required string RequestorId { get; set; }
    [Column("document")]
    public required string Document { get; set; }
    [Column("temp_id")]
    public required string TempId { get; set; }
}
