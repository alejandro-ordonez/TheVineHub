using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.Cells.Dtos;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.GetCells
{
    public class GetCellsQuery : IQuery<IEnumerable<CellDto>>
    {
        [Column("document")]
        public required string Document { get; set; }
    }
}
