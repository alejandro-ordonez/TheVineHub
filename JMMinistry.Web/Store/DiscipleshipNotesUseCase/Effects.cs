using JMMinistry.Common.Dtos.Discipleship;
using Fluxor;
using JMMinistry.Web.Api;
using JMMinistry.Web.Store.DiscipleshipNotesUseCase.Actions;

namespace JMMinistry.Web.Store.DiscipleshipNotesUseCase
{
    public class Effects(IUserApi userApi, IDiscipleshipApi discipleshipApi)
    {
        [EffectMethod]
        public async Task HandleCheckIsLeaderAction(CheckIsLeaderAction action, IDispatcher dispatcher)
        {
            var response = await userApi.IsLeaderOfAsync(action.DiscipleId);

            if (response is null || !response.Success)
            {
                dispatcher.Dispatch(new FailedAction<CheckIsLeaderAction>());
                dispatcher.Dispatch(new CheckIsLeaderResultAction { IsLeader = false, DiscipleId = action.DiscipleId });
                return;
            }

            dispatcher.Dispatch(new CheckIsLeaderResultAction { IsLeader = response.Data, DiscipleId = action.DiscipleId });
        }

        [EffectMethod]
        public async Task HandleFetchDiscipleshipNotesAction(FetchDiscipleshipNotesAction action, IDispatcher dispatcher)
        {
            var response = await discipleshipApi.GetNotesAsync(action.DiscipleId);

            if (response is null || response.Data is null || !response.Success)
            {
                dispatcher.Dispatch(new FailedAction<FetchDiscipleshipNotesAction>());
                return;
            }

            dispatcher.Dispatch(new FetchDiscipleshipNotesResultAction { Notes = response.Data });
        }

        [EffectMethod]
        public async Task HandleCreateNoteAction(CreateNoteAction action, IDispatcher dispatcher)
        {
            var dto = new CreateDiscipleshipNoteDto
            {
                Title = action.Title,
                Description = action.Description,
                Categories = action.Categories
            };

            var response = await discipleshipApi.CreateNoteAsync(action.DiscipleId, dto);

            if (response is null || response.Data is null || !response.Success)
            {
                dispatcher.Dispatch(new FailedAction<CreateNoteAction>());
                return;
            }

            dispatcher.Dispatch(new CreateNoteResultAction { Note = response.Data });
            dispatcher.Dispatch(new FetchDiscipleshipNotesAction { DiscipleId = action.DiscipleId });
        }

        [EffectMethod]
        public async Task HandleFetchNoteEntriesAction(FetchNoteEntriesAction action, IDispatcher dispatcher)
        {
            var response = await discipleshipApi.GetNoteEntriesAsync(action.DiscipleId, action.NoteId);

            if (response is null || response.Data is null || !response.Success)
            {
                dispatcher.Dispatch(new FailedAction<FetchNoteEntriesAction>());
                return;
            }

            dispatcher.Dispatch(new FetchNoteEntriesResultAction { NoteId = action.NoteId, Entries = response.Data });
        }

        [EffectMethod]
        public async Task HandleCreateNoteEntryAction(CreateNoteEntryAction action, IDispatcher dispatcher)
        {
            var dto = new CreateDiscipleshipNoteEntryDto
            {
                Content = action.Content,
                Date = action.Date
            };

            var response = await discipleshipApi.CreateNoteEntryAsync(action.DiscipleId, action.NoteId, dto);

            if (response is null || response.Data is null || !response.Success)
            {
                dispatcher.Dispatch(new FailedAction<CreateNoteEntryAction>());
                return;
            }

            dispatcher.Dispatch(new CreateNoteEntryResultAction { NoteId = action.NoteId, Entry = response.Data });
            dispatcher.Dispatch(new FetchNoteEntriesAction { DiscipleId = action.DiscipleId, NoteId = action.NoteId });
        }
    }
}
