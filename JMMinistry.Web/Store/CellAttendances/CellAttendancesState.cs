using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellAttendances
{
    public record CellAttendancesState : BaseState
    {
        public int CellId { get; set; }
        public IList<CellAttendanceDto> Attendances { get; set; } = [];
    }
}
