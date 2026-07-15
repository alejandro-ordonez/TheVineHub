using TheVineHub.API.Common;
using Mediator;

namespace TheVineHub.API.Features.Cells.CellCheckIsAuthorized
{
    public sealed class CellCheckIsAuthorizedQuery : IQuery<bool>
    {
        public required string CellId { get; init; }
        public IList<Roles> AllowedRoles { get; init; } = [];
        public required string RequestorId { get; init; }
    }
}
