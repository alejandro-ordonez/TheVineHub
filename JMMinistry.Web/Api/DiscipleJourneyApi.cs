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
    }
}
