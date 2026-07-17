using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.DiscipleJourney.Cycles
{
    public class CreateStepCycleRequest
    {
        public required string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public DateOnly? EnrollmentDeadline { get; set; }
    }
}
