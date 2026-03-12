using Fluxor;
using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.CycleDetailsUseCase
{
    [FeatureState]
    public record CycleDetailsState : BaseState
    {
        public IList<CycleSessionDto> Sessions { get; set; } = [];
        public IList<CycleEnrollmentDto> Enrollments { get; set; } = [];
        public IList<CycleAttendanceDto> Attendance { get; set; } = [];
        public IList<CycleStaffDto> Staff { get; set; } = [];
        public bool IsLoadingSessions { get; set; }
        public bool IsLoadingAttendance { get; set; }
        public bool IsLoadingStaff { get; set; }
        public int? CurrentCycleId { get; set; }
    }
}
