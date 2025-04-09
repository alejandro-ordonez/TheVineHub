using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Meetings;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public interface IMeetingApi
    {
        Task<Response<MeetingDto>?> CreateMeeting(CreateMeetingDto meeting);

        Task<Response<IList<MeetingDto>>?> GetMeetings();
    }

    public class MeetingApi(IHttpClientFactory clientFactory) : IMeetingApi
    {
        private const string _meetinApi = "api/Meetings";

        public async Task<Response<MeetingDto>?> CreateMeeting(CreateMeetingDto meeting)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.PostAsJsonAsync(_meetinApi, meeting);
            return await response.Content.ReadFromJsonAsync<Response<MeetingDto>>();
        }

        public async Task<Response<IList<MeetingDto>>?> GetMeetings()
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = await client.GetFromJsonAsync<Response<IList<MeetingDto>>?>(_meetinApi);
            return response;
        }
    }
}
