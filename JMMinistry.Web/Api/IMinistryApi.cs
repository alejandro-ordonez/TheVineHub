using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Api
{
    public interface IMinistryApi
    {
        Task<Response<IList<CellDto>>?> GetAsync();
        Task<Response<CellDto>?> CreateCell(CreateCellDto cell);
        Task<Response<CellDto>?> AddDisciples(AddDisciplesDto addDisciples);
    }
}
