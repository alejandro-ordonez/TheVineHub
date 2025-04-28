using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellAttendances.Actions
{
    public record FetchCellAttendancesAction
    {
        public required int CellId { get; set; }
    }

    public record FetchCellAttendancesResultAction
    {
        public IList<CellAttendanceDto> Attendances { get; set; } = [];
    }
}
