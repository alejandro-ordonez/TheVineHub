using JMMinistry.Common;
using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Api
{
    public interface IDiscipleJourneyApi
    {
        Task<Response<IList<DiscipleStepDto>>?> GetStepsAsync(bool forceFresh = false);
        Task<Response<DiscipleStepDto>?> CreateStepAsync(CreateDiscipleStepDto dto);
        Task<Response<DiscipleStepDto>?> UpdateStepAsync(int stepId, UpdateDiscipleStepDto dto);
        Task<bool> DeleteStepAsync(int stepId);
        Task<Response<IList<StepDisciplesByCellDto>>?> GetStepDisciplesAsync(int stepId, int? cellId = null);
        Task<Response<IList<StepDisciplesByCellDto>>?> GetEligibleDisciplesAsync(int stepId);
        Task<bool> CompleteStepAsync(int stepId, CompleteStepDto dto);
        Task<bool> UpdateStepCompletionAsync(int stepId, string discipleId, UpdateStepCompletionDto dto);

        // Step Cycles
        Task<Response<IList<StepCycleDto>>?> GetStepCyclesAsync(int stepId);
        Task<Response<IList<StepCycleDto>>?> GetActiveCyclesForStepAsync(int stepId);
        Task<Response<StepCycleDto>?> CreateStepCycleAsync(int stepId, CreateStepCycleDto dto);
        Task<Response<StepCycleDto>?> UpdateStepCycleAsync(int stepId, int cycleId, UpdateStepCycleDto dto);
        Task<bool> DeleteStepCycleAsync(int stepId, int cycleId);

        // Cycle Sessions
        Task<Response<IList<CycleSessionDto>>?> GetCycleSessionsAsync(int cycleId);
        Task<Response<CycleSessionDto>?> CreateCycleSessionAsync(int cycleId, CreateCycleSessionDto dto);
        Task<bool> DeleteCycleSessionAsync(int cycleId, int sessionId);

        // Cycle Staff
        Task<Response<IList<CycleStaffDto>>?> GetCycleStaffAsync(int cycleId);
        Task<Response<CycleStaffDto>?> AddCycleStaffAsync(int cycleId, CreateCycleStaffDto dto);
        Task<bool> RemoveCycleStaffAsync(int cycleId, int staffId);

        // Cycle Enrollments
        Task<bool> EnrollDisciplesAsync(int cycleId, EnrollDisciplesDto dto);
        Task<bool> UpdateEnrollmentStatusAsync(int cycleId, int enrollmentId, UpdateEnrollmentStatusDto dto);
        Task<bool> AssignGuideAsync(int cycleId, AssignGuideDto dto);

        // Cycle Attendance
        Task<Response<IList<CycleAttendanceDto>>?> GetCycleAttendanceAsync(int cycleId);
        Task<bool> RecordCycleAttendanceAsync(int cycleId, int sessionId, RecordCycleAttendanceDto dto);

        // Cycle Details
        Task<Response<IList<CycleEnrollmentDto>>?> GetCycleDetailsAsync(int cycleId);
        Task<Response<IList<CycleEnrollmentDto>>?> GetCycleEnrollmentsAsync(int cycleId);
    }
}
