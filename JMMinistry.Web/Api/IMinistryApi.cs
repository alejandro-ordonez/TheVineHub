using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Api
{
    public interface IMinistryApi
    {
        Task<Response<IList<CellDto>>?> GetAsync();
    }
}
