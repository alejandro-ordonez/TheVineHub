using JMMinistry.Common;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized
{
    public class CellCheckIsAuthorizedQuery : IQuery<bool>
    {
        public required string CellId { get; set; }
        public IList<Roles> AllowedRoles { get; set; } = [];
        public required string RequestorId { get; set; }
    }
}
