using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.Cells.Dtos;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.GetCellAttendances
{
    public class GetCellAttendancesQuery : IQuery<IList<CellAttendanceDto>>
    {
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("cell_id")]
        public required string CellId { get; set; }
    }
}
