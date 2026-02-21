using Fluxor;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using JMMinistry.Web.Pages.User;
using JMMinistry.Web.Shared.Components;
using JMMinistry.Web.Store.CellAttendances.Actions;
using JMMinistry.Web.Store.DisciplesUseCase;
using JMMinistry.Web.Store.DisciplesUseCase.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.Ministry.Cells
{
    public partial class Disciples
    {
        [Parameter]
        public required int CellId { get; set; }


        [Inject]
        public required IState<DisciplesInCellState> State { get; set; }

        [Inject]
        public required IDialogService DialogService { get; set; }

        [Inject]
        public required IDispatcher Dispatcher { get; set; }

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        [Inject]
        public required IUserApi UserApi { get; set; }

        private Dictionary<string, UserCard> UserCards { get; set; } = [];

        private string? AttendanceNotes { get; set; }


#pragma warning disable S2376 // Write-only properties should not be used
        UserCard? ComponentRef { set => UserCards[value!.User.Document] = value; }
#pragma warning restore S2376 // Write-only properties should not be used

        private bool AddAttendanceEnabled { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Dispatcher.Dispatch(new FetchDisciplesAction { CellId = CellId });
        }

        void AddAttendance()
        {
            var disciples = UserCards.Where(card => card.Value.Selected)
                .Select(card => card.Key)
                .ToList();

            if (disciples.Count == 0)
                return;

            Dispatcher.Dispatch(new AddCellAttendanceAction { CellId = CellId, Documents = disciples, Notes = AttendanceNotes });

            AddAttendanceEnabled = false;
        }

        async Task OpenAddDisciple()
        {
            var dialog = await DialogService.ShowAsync<AddUserDialog>(translator["AddDisciples"]);
            var result = await dialog.GetReturnValueAsync<DialogResult<CreateUserInfoDto>>();

            if (result?.Data is null)
                return;

            if (result.Option == DialogResultOption.SecondaryButton)
            {
                Dispatcher.Dispatch(new AddDisciplesAction { CellId = CellId, Documents = [result.Data.Document] });
                return;
            }

            var response = await UserApi.CreateUser(result.Data);

            if (response?.Success ?? false)
            {
                Dispatcher.Dispatch(new AddDisciplesAction { CellId = CellId, Documents = [result.Data.Document] });
            }
        }

        async Task ShowUserDetails(UserEventArgs user)
        {
            var parameters = new DialogParameters<UserDetailsDialog>
            {
                {x => x.Document, user.Document }
            };

            var dialog = await DialogService.ShowAsync<UserDetailsDialog>(translator["Details"], parameters);
            var result = await dialog.GetReturnValueAsync<DialogResult<UserEventArgs>>();

            if (result is null || result.Data is null)
                return;

            switch (result.Option)
            {
                case DialogResultOption.PrimaryButton:
                    NavigationManager.NavigateTo($"{Routes.User}/{user.Document}");
                    break;

                case DialogResultOption.SecondaryButton:
                    await RemoveDisciple(result.Data);
                    break;
            }
        }

        async Task RemoveDisciple(UserEventArgs eventArgs)
        {
            var parameters = new DialogParameters<ConfirmationDialog>
            {
                {x => x.ButtonText, translator["Remove"] },
                {x => x.ContentText, translator["AreYouSure", translator["Remove"], translator["Disciple"], eventArgs.Document] },
                {x => x.Color, Color.Error },
            };

            var dialog = await DialogService.ShowAsync<ConfirmationDialog>(translator["Remove"], parameters);
            var result = await dialog.Result;

            if (!result?.Canceled ?? false)
                Dispatcher.Dispatch(new RemoveDiscipleAction { CellId = CellId, DiscipleId = eventArgs.Document });
        }
    }
}
