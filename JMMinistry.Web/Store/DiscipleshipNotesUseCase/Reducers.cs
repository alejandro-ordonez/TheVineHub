using JMMinistry.Common.Dtos.Discipleship;
using Fluxor;
using JMMinistry.Web.Store.DiscipleshipNotesUseCase.Actions;

namespace JMMinistry.Web.Store.DiscipleshipNotesUseCase
{
    public static class Reducers
    {
        [ReducerMethod(typeof(CheckIsLeaderAction))]
        public static DiscipleshipNotesState ReduceCheckIsLeaderAction(DiscipleshipNotesState state)
            => state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleshipNotesState ReduceCheckIsLeaderResultAction(DiscipleshipNotesState state, CheckIsLeaderResultAction action)
            => state with { IsLoading = false, IsLeader = action.IsLeader, DiscipleId = action.DiscipleId };

        [ReducerMethod(typeof(FetchDiscipleshipNotesAction))]
        public static DiscipleshipNotesState ReduceFetchDiscipleshipNotesAction(DiscipleshipNotesState state)
            => state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleshipNotesState ReduceFetchDiscipleshipNotesResultAction(DiscipleshipNotesState state, FetchDiscipleshipNotesResultAction action)
            => state with { IsLoading = false, Notes = action.Notes };

        [ReducerMethod(typeof(CreateNoteAction))]
        public static DiscipleshipNotesState ReduceCreateNoteAction(DiscipleshipNotesState state)
            => state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleshipNotesState ReduceCreateNoteResultAction(DiscipleshipNotesState state, CreateNoteResultAction action)
            => state with { IsLoading = false };

        [ReducerMethod(typeof(FetchNoteEntriesAction))]
        public static DiscipleshipNotesState ReduceFetchNoteEntriesAction(DiscipleshipNotesState state)
            => state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleshipNotesState ReduceFetchNoteEntriesResultAction(DiscipleshipNotesState state, FetchNoteEntriesResultAction action)
        {
            var updated = new Dictionary<int, IList<DiscipleshipNoteEntryDto>>(state.EntriesByNoteId)
            {
                [action.NoteId] = action.Entries
            };
            return state with { IsLoading = false, EntriesByNoteId = updated };
        }

        [ReducerMethod(typeof(CreateNoteEntryAction))]
        public static DiscipleshipNotesState ReduceCreateNoteEntryAction(DiscipleshipNotesState state)
            => state with { IsLoading = true };

        [ReducerMethod]
        public static DiscipleshipNotesState ReduceCreateNoteEntryResultAction(DiscipleshipNotesState state, CreateNoteEntryResultAction action)
            => state with { IsLoading = false };

        [ReducerMethod]
        public static DiscipleshipNotesState ReduceSelectNoteAction(DiscipleshipNotesState state, SelectNoteAction action)
            => state with { SelectedNoteId = action.NoteId };
    }
}
