namespace JMMinistry.Web.Store.CellAttendances.Actions
{
    public record AddCellAttendanceAction
    {
        public required int CellId { get; set; }
        public required List<string> Documents { get; set; }
        public string? Notes { get; set; } 
    }
}
