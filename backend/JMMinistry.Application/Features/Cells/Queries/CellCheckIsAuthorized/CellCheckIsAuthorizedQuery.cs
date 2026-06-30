using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Common;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized
{
    public class CellCheckIsAuthorizedQuery : IQuery<bool>
    {
        [Column("cell_id")]
        public required string CellId { get; set; }
        [Column("allowed_roles")]
        public IList<Roles> AllowedRoles { get; set; } = [];
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
    }
}
