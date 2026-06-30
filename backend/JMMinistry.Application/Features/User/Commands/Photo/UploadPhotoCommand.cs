using System.ComponentModel.DataAnnotations.Schema;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class UploadPhotoCommand : ICommand<string>
{
    [Column("requestor_id")]
    public required string RequestorId { get; set; }
    [Column("document")]
    public required string Document { get; set; }
    [Column("image_stream")]
    public required Stream ImageStream { get; set; }
}
