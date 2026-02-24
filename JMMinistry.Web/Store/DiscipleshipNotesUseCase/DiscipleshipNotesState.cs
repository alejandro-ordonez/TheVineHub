using Fluxor;
using JMMinistry.Common.Dtos.Discipleship;

namespace JMMinistry.Web.Store.DiscipleshipNotesUseCase
{
    [FeatureState]
    public record DiscipleshipNotesState : BaseState
    {
        public IList<DiscipleshipNoteDto> Notes { get; set; } = [];
        public bool IsLeader { get; set; } = false;
        public string DiscipleId { get; set; } = string.Empty;
        public Dictionary<int, IList<DiscipleshipNoteEntryDto>> EntriesByNoteId { get; set; } = [];
        public int? SelectedNoteId { get; set; }

        private DiscipleshipNotesState() { }
    }
}
