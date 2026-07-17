using Mediator;
using Microsoft.AspNetCore.Http;

namespace TheVineHub.API.Features.Users.ImportUsers
{
    public sealed class ImportUsersCommand : ICommand<string>
    {
        public required IFormFile File { get; init; }
    }
}
