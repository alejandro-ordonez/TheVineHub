using System.ComponentModel.DataAnnotations.Schema;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class UploadTempPhotoCommand : ICommand<string>
{
    [Column("image_stream")]
    public required Stream ImageStream { get; set; }
}
