using Mediator;
using System.IO;

namespace TheVineHub.API.Features.Users.Photos
{
    public sealed class AssignTempPhotoCommand : ICommand<string>
    {
        public required string RequestorId { get; init; }
        public required string Document { get; init; }
        public required string TempId { get; init; }
    }

    public sealed class DeletePhotoCommand : ICommand
    {
        public required string RequestorId { get; init; }
        public required string Document { get; init; }
    }

    public sealed class GetPhotoUploadUrlCommand : ICommand<string>
    {
        public string FileName { get; init; } = string.Empty;
    }

    public sealed class UploadPhotoCommand : ICommand<string>
    {
        public required string RequestorId { get; init; }
        public required string Document { get; init; }
        public required Stream ImageStream { get; init; }
    }

    public sealed class UploadTempPhotoCommand : ICommand<string>
    {
        public required Stream ImageStream { get; init; }
    }
}
