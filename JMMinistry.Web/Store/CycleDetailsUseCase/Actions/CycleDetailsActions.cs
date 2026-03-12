using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Store.CycleDetailsUseCase.Actions
{
    public record FetchCycleDetailsAction
    {
        public required int CycleId { get; set; }
    }

    public record FetchCycleDetailsResultAction
    {
        public IList<CycleEnrollmentDto> Enrollments { get; set; } = [];
    }

    public record FetchCycleSessionsAction
    {
        public required int CycleId { get; set; }
    }

    public record FetchCycleSessionsResultAction
    {
        public IList<CycleSessionDto> Sessions { get; set; } = [];
    }

    public record FetchCycleAttendanceAction
    {
        public required int CycleId { get; set; }
    }

    public record FetchCycleAttendanceResultAction
    {
        public IList<CycleAttendanceDto> Attendance { get; set; } = [];
    }

    public record CreateCycleSessionAction
    {
        public required int CycleId { get; set; }
        public required CreateCycleSessionDto Dto { get; set; }
    }

    public record CreateCycleSessionResultAction;

    public record DeleteCycleSessionAction
    {
        public required int CycleId { get; set; }
        public required int SessionId { get; set; }
    }

    public record DeleteCycleSessionResultAction;

    public record FetchCycleStaffAction
    {
        public required int CycleId { get; set; }
    }

    public record FetchCycleStaffResultAction
    {
        public IList<CycleStaffDto> Staff { get; set; } = [];
    }

    public record AddCycleStaffAction
    {
        public required int CycleId { get; set; }
        public required CreateCycleStaffDto Dto { get; set; }
    }

    public record AddCycleStaffResultAction;

    public record RemoveCycleStaffAction
    {
        public required int CycleId { get; set; }
        public required int StaffId { get; set; }
    }

    public record RemoveCycleStaffResultAction;

    public record EnrollDisciplesAction
    {
        public required int CycleId { get; set; }
        public required EnrollDisciplesDto Dto { get; set; }
    }

    public record EnrollDisciplesResultAction;

    public record UpdateEnrollmentStatusAction
    {
        public required int CycleId { get; set; }
        public required int EnrollmentId { get; set; }
        public required UpdateEnrollmentStatusDto Dto { get; set; }
    }

    public record UpdateEnrollmentStatusResultAction;

    public record AssignGuideAction
    {
        public required int CycleId { get; set; }
        public required AssignGuideDto Dto { get; set; }
    }

    public record AssignGuideResultAction;

    public record RecordCycleAttendanceAction
    {
        public required int CycleId { get; set; }
        public required int SessionId { get; set; }
        public required RecordCycleAttendanceDto Dto { get; set; }
    }

    public record RecordCycleAttendanceResultAction;
}
