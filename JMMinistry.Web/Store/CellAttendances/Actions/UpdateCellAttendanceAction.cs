namespace JMMinistry.Web.Store.CellAttendances.Actions
{
    public record UpdateCellAttendanceAction
    {
        public required int CellId { get; set; }
        public required int AttendanceId { get; set; }
        public required List<string> Documents { get; set; }
        public string? Notes { get; set; }
        public required DateTime Date { get; set; }
    }
}
