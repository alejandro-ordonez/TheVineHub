using JMMinistry.Common;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.Meetings;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public interface ILocationApi
    {
        Task<Response<IList<CityDto>>?> GetCitiesAsync(string? searchTerm);
        Task<IEnumerable<CityDto>> GetCities(string searchTerm);
    }   

    public class LocationApi(IHttpClientFactory clientFactory) : ILocationApi
    {
        public const string _locationApi = "api/Location";

        public async Task<Response<IList<CityDto>>?> GetCitiesAsync(string? searchTerm)
        {
            using var client = clientFactory.CreateClient(Constants.ApiClient);
            var path = _locationApi;

            if (!string.IsNullOrEmpty(searchTerm)) 
                path += "?searchTerm" + searchTerm;

            var response = await client.GetAsync(path);
            return await response.Content.ReadFromJsonAsync<Response<IList<CityDto>>?>();
        }

        public async Task<IEnumerable<CityDto>> GetCities(string searchTerm)
        {
            var result = await GetCitiesAsync(searchTerm);

            if (result is null || result.Data is null || result.Data.Count == 0)
                return [];

            return result.Data;
        }
    }
}
