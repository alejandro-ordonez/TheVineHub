using JMMinistry.Common;
using JMMinistry.Common.Dtos.Discipleship;

namespace JMMinistry.Web.Api
{
    public interface IDiscipleshipApi
    {
        Task<Response<IList<DiscipleshipNoteDto>>?> GetNotesAsync(string discipleId);
        Task<Response<DiscipleshipNoteDto>?> GetNoteByIdAsync(string discipleId, int noteId);
        Task<Response<DiscipleshipNoteDto>?> CreateNoteAsync(string discipleId, CreateDiscipleshipNoteDto dto);
        Task<Response<IList<DiscipleshipNoteEntryDto>>?> GetNoteEntriesAsync(string discipleId, int noteId);
        Task<Response<DiscipleshipNoteEntryDto>?> CreateNoteEntryAsync(string discipleId, int noteId, CreateDiscipleshipNoteEntryDto dto);
    }
}
