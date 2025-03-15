using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Api
{
    public interface IMinistryApi
    {
        Task<Response<IList<CellDto>>?> GetAsync();
        Task<Response<CellDto>?> CreateCell(CreateCellDto cell);
        Task<Response<IList<PartialUserInfoDto>>?> AddDisciples(AddDisciplesDto addDisciples);
        Task<Response<IList<PartialUserInfoDto>>?> RemoveDiscipleFromCell(int cellId, string document);
        Task<Response<IList<PartialUserInfoDto>>?> GetDisciples(int cellId);
    }
}
