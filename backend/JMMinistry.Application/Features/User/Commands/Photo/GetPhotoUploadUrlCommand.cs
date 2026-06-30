using System.ComponentModel.DataAnnotations.Schema;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class GetPhotoUploadUrlCommand : ICommand<string>
{
    [Column("file_name")]
    public string FileName { get; set; } = string.Empty;
}
