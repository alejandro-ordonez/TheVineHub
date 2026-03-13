using JMMinistry.Common;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class DiscipleJourneyApi(IHttpClientFactory clientFactory) : IDiscipleJourneyApi
    {
        private const string _discipleJourneyApi = "api/DiscipleJourney";

        public async Task<Response<IList<DiscipleStepDto>>?> GetStepsAsync()
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/steps");
            return await response.Content.ReadFromJsonAsync<Response<IList<DiscipleStepDto>>?>();
        }

        public async Task<Response<DiscipleStepDto>?> CreateStepAsync(CreateDiscipleStepDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleJourneyApi}/steps", dto);
            return await response.Content.ReadFromJsonAsync<Response<DiscipleStepDto>?>();
        }

        public async Task<Response<DiscipleStepDto>?> UpdateStepAsync(int stepId, UpdateDiscipleStepDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PutAsJsonAsync($"{_discipleJourneyApi}/steps/{stepId}", dto);
            return await response.Content.ReadFromJsonAsync<Response<DiscipleStepDto>?>();
        }

        public async Task<bool> DeleteStepAsync(int stepId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.DeleteAsync($"{_discipleJourneyApi}/steps/{stepId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Response<IList<StepDisciplesByCellDto>>?> GetStepDisciplesAsync(int stepId, int? cellId = null)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var url = $"{_discipleJourneyApi}/steps/{stepId}/disciples";
            if (cellId.HasValue)
                url += $"?cellId={cellId.Value}";
            var response = await client.GetAsync(url);
            return await response.Content.ReadFromJsonAsync<Response<IList<StepDisciplesByCellDto>>?>();
        }

        public async Task<Response<IList<StepDisciplesByCellDto>>?> GetEligibleDisciplesAsync(int stepId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/steps/{stepId}/eligible-disciples");
            return await response.Content.ReadFromJsonAsync<Response<IList<StepDisciplesByCellDto>>?>();
        }

        public async Task<bool> CompleteStepAsync(int stepId, CompleteStepDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleJourneyApi}/steps/{stepId}/completions", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateStepCompletionAsync(int stepId, string discipleId, UpdateStepCompletionDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PutAsJsonAsync($"{_discipleJourneyApi}/steps/{stepId}/completions/{discipleId}", dto);
            return response.IsSuccessStatusCode;
        }

        // ===== Step Cycles =====

        public async Task<Response<IList<StepCycleDto>>?> GetStepCyclesAsync(int stepId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/steps/{stepId}/cycles");
            return await response.Content.ReadFromJsonAsync<Response<IList<StepCycleDto>>?>();
        }

        public async Task<Response<IList<StepCycleDto>>?> GetActiveCyclesForStepAsync(int stepId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/steps/{stepId}/cycles/active");
            return await response.Content.ReadFromJsonAsync<Response<IList<StepCycleDto>>?>();
        }

        public async Task<Response<StepCycleDto>?> CreateStepCycleAsync(int stepId, CreateStepCycleDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleJourneyApi}/steps/{stepId}/cycles", dto);
            return await response.Content.ReadFromJsonAsync<Response<StepCycleDto>?>();
        }

        public async Task<Response<StepCycleDto>?> UpdateStepCycleAsync(int stepId, int cycleId, UpdateStepCycleDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PutAsJsonAsync($"{_discipleJourneyApi}/steps/{stepId}/cycles/{cycleId}", dto);
            return await response.Content.ReadFromJsonAsync<Response<StepCycleDto>?>();
        }

        public async Task<bool> DeleteStepCycleAsync(int stepId, int cycleId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.DeleteAsync($"{_discipleJourneyApi}/steps/{stepId}/cycles/{cycleId}");
            return response.IsSuccessStatusCode;
        }

        // ===== Cycle Sessions =====

        public async Task<Response<IList<CycleSessionDto>>?> GetCycleSessionsAsync(int cycleId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/cycles/{cycleId}/sessions");
            return await response.Content.ReadFromJsonAsync<Response<IList<CycleSessionDto>>?>();
        }

        public async Task<Response<CycleSessionDto>?> CreateCycleSessionAsync(int cycleId, CreateCycleSessionDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleJourneyApi}/cycles/{cycleId}/sessions", dto);
            return await response.Content.ReadFromJsonAsync<Response<CycleSessionDto>?>();
        }

        public async Task<bool> DeleteCycleSessionAsync(int cycleId, int sessionId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.DeleteAsync($"{_discipleJourneyApi}/cycles/{cycleId}/sessions/{sessionId}");
            return response.IsSuccessStatusCode;
        }

        // ===== Cycle Staff =====

        public async Task<Response<IList<CycleStaffDto>>?> GetCycleStaffAsync(int cycleId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/cycles/{cycleId}/staff");
            return await response.Content.ReadFromJsonAsync<Response<IList<CycleStaffDto>>?>();
        }

        public async Task<Response<CycleStaffDto>?> AddCycleStaffAsync(int cycleId, CreateCycleStaffDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleJourneyApi}/cycles/{cycleId}/staff", dto);
            return await response.Content.ReadFromJsonAsync<Response<CycleStaffDto>?>();
        }

        public async Task<bool> RemoveCycleStaffAsync(int cycleId, int staffId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.DeleteAsync($"{_discipleJourneyApi}/cycles/{cycleId}/staff/{staffId}");
            return response.IsSuccessStatusCode;
        }

        // ===== Cycle Enrollments =====

        public async Task<bool> EnrollDisciplesAsync(int cycleId, EnrollDisciplesDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleJourneyApi}/cycles/{cycleId}/enrollments", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEnrollmentStatusAsync(int cycleId, int enrollmentId, UpdateEnrollmentStatusDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PutAsJsonAsync($"{_discipleJourneyApi}/cycles/{cycleId}/enrollments/{enrollmentId}/status", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AssignGuideAsync(int cycleId, AssignGuideDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PutAsJsonAsync($"{_discipleJourneyApi}/cycles/{cycleId}/enrollments/assign-guide", dto);
            return response.IsSuccessStatusCode;
        }

        // ===== Cycle Attendance =====

        public async Task<Response<IList<CycleAttendanceDto>>?> GetCycleAttendanceAsync(int cycleId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/cycles/{cycleId}/attendance");
            return await response.Content.ReadFromJsonAsync<Response<IList<CycleAttendanceDto>>?>();
        }

        public async Task<bool> RecordCycleAttendanceAsync(int cycleId, int sessionId, RecordCycleAttendanceDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleJourneyApi}/cycles/{cycleId}/sessions/{sessionId}/attendance", dto);
            return response.IsSuccessStatusCode;
        }

        // ===== Cycle Details =====

        public async Task<Response<IList<CycleEnrollmentDto>>?> GetCycleDetailsAsync(int cycleId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/cycles/{cycleId}/details");
            return await response.Content.ReadFromJsonAsync<Response<IList<CycleEnrollmentDto>>?>();
        }

        public async Task<Response<IList<CycleEnrollmentDto>>?> GetCycleEnrollmentsAsync(int cycleId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleJourneyApi}/cycles/{cycleId}/enrollments");
            return await response.Content.ReadFromJsonAsync<Response<IList<CycleEnrollmentDto>>?>();
        }
    }
}
