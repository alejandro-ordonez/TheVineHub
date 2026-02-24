using JMMinistry.Common;
using JMMinistry.Common.Dtos.Discipleship;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class DiscipleshipApi(IHttpClientFactory clientFactory) : IDiscipleshipApi
    {
        private const string _discipleshipApi = "api/Discipleship";

        public async Task<Response<IList<DiscipleshipNoteDto>>?> GetNotesAsync(string discipleId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleshipApi}/{discipleId}/notes");
            return await response.Content.ReadFromJsonAsync<Response<IList<DiscipleshipNoteDto>>?>();
        }

        public async Task<Response<DiscipleshipNoteDto>?> GetNoteByIdAsync(string discipleId, int noteId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleshipApi}/{discipleId}/notes/{noteId}");
            return await response.Content.ReadFromJsonAsync<Response<DiscipleshipNoteDto>?>();
        }

        public async Task<Response<DiscipleshipNoteDto>?> CreateNoteAsync(string discipleId, CreateDiscipleshipNoteDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleshipApi}/{discipleId}/notes", dto);
            return await response.Content.ReadFromJsonAsync<Response<DiscipleshipNoteDto>?>();
        }

        public async Task<Response<IList<DiscipleshipNoteEntryDto>>?> GetNoteEntriesAsync(string discipleId, int noteId)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetAsync($"{_discipleshipApi}/{discipleId}/notes/{noteId}/entries");
            return await response.Content.ReadFromJsonAsync<Response<IList<DiscipleshipNoteEntryDto>>?>();
        }

        public async Task<Response<DiscipleshipNoteEntryDto>?> CreateNoteEntryAsync(string discipleId, int noteId, CreateDiscipleshipNoteEntryDto dto)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync($"{_discipleshipApi}/{discipleId}/notes/{noteId}/entries", dto);
            return await response.Content.ReadFromJsonAsync<Response<DiscipleshipNoteEntryDto>?>();
        }
    }
}
