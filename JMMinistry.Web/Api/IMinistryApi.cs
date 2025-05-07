using JMMinistry.Common;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Api
{
    public interface IMinistryApi
    {
        Task<Response<IList<CellDto>>?> GetAsync();
        Task<Response<CellDto>?> GetAsync(int cellId);
        Task<Response<CellDto>?> CreateCell(CellDto cell);
        Task<Response<IList<PartialUserInfoDto>>?> AddDisciples(AddDisciplesDto addDisciples);
        Task<Response<IList<PartialUserInfoDto>>?> RemoveDiscipleFromCell(int cellId, string document);
        Task<Response<IList<PartialUserInfoDto>>?> GetDisciples(int cellId);
        Task<Response<object>?> UpdateCellAsync(CellDto cell);

        Task<Response<object>?> RecordCellAttendance(int cellId, AddCellAttendanceDto cellAttendance);
        Task<Response<IList<CellAttendanceDto>>?> GetCellAttendances(int cellId);
    }
}
