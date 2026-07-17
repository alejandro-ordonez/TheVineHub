using TheVineHub.API.Features.Users;
using Mediator;

namespace TheVineHub.API.Features.Users.CheckDocument
{
    public sealed class CheckDocumentExistsQuery : IQuery<DocumentCheckResultDto>
    {
        public required string Document { get; init; }
    }
}
