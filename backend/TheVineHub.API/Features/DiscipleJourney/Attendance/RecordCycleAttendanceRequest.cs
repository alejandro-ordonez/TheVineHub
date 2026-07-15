using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.DiscipleJourney.Attendance
{
    public class RecordCycleAttendanceRequest
    {
        public IList<string> DiscipleIds { get; set; } = [];
    }
}
