using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Web.Shared;
using System.Net.Http.Json;

namespace JMMinistry.Web.Api
{
    public class MinistryApi(IHttpClientFactory clientFactory) : IMinistryApi
    {
        private const string _ministryApi = "api/Ministry";

        public Task<Response<IList<CellDto>>?> GetAsync()
        {
            var client = clientFactory.CreateClient(Constants.ApiClient);
            var response = client.GetFromJsonAsync<Response<IList<CellDto>>?>(_ministryApi);
            return response;
        }
    }
}
