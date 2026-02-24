using JMMinistry.Common.Dtos.Discipleship;

namespace JMMinistry.Web.Store.DiscipleshipNotesUseCase.Actions
{
    public record CheckIsLeaderAction
    {
        public required string DiscipleId { get; set; }
    }

    public record CheckIsLeaderResultAction
    {
        public required bool IsLeader { get; set; }
        public required string DiscipleId { get; set; }
    }

    public record FetchDiscipleshipNotesAction
    {
        public required string DiscipleId { get; set; }
    }

    public record FetchDiscipleshipNotesResultAction
    {
        public required IList<DiscipleshipNoteDto> Notes { get; set; }
    }

    public record CreateNoteAction
    {
        public required string DiscipleId { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = [];
    }

    public record CreateNoteResultAction
    {
        public required DiscipleshipNoteDto Note { get; set; }
    }

    public record FetchNoteEntriesAction
    {
        public required string DiscipleId { get; set; }
        public required int NoteId { get; set; }
    }

    public record FetchNoteEntriesResultAction
    {
        public required int NoteId { get; set; }
        public required IList<DiscipleshipNoteEntryDto> Entries { get; set; }
    }

    public record CreateNoteEntryAction
    {
        public required string DiscipleId { get; set; }
        public required int NoteId { get; set; }
        public required string Content { get; set; }
        public DateTime Date { get; set; }
    }

    public record CreateNoteEntryResultAction
    {
        public required int NoteId { get; set; }
        public required DiscipleshipNoteEntryDto Entry { get; set; }
    }

    public record SelectNoteAction
    {
        public int? NoteId { get; set; }
    }
}
