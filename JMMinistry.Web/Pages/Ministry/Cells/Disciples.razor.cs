using Fluxor;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using JMMinistry.Web.Pages.User.Components;
using JMMinistry.Web.Pages.User.Dialogs;
using JMMinistry.Web.Shared.Components;
using JMMinistry.Web.Store.CellAttendances.Actions;
using JMMinistry.Web.Store.DisciplesUseCase;
using JMMinistry.Web.Store.DisciplesUseCase.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static JMMinistry.Web.Pages.Ministry.Cells.MarryDialog;
using JMMinistry.Common;

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
            var result = await dialog.GetReturnValueAsync<DialogResult<AddUserDialog.AddUserResult>>();

            if (result?.Data is null)
                return;

            var userDto = result.Data.User;
            var response = userDto.IsUpdate
                ? await UserApi.UpdateUser(userDto)
                : await UserApi.CreateUser(userDto);

            if (response?.Success ?? false)
            {
                if (result.Data.TempPhotoId is not null)
                    await UserApi.AssignTempPhotoAsync(userDto.Document, result.Data.TempPhotoId);

                Dispatcher.Dispatch(new AddDisciplesAction { CellId = CellId, Documents = [userDto.Document] });
            }
        }

        async Task OpenMarryDialog()
        {
            var parameters = new DialogParameters<MarryDialog>
            {
                { x => x.Disciples, State.Value.Disciples }
            };

            var dialog = await DialogService.ShowAsync<MarryDialog>(translator["Marry"], parameters);
            var result = await dialog.GetReturnValueAsync<MarryDialogResult>();

            if (result is null) return;

            var person = State.Value.Disciples.FirstOrDefault(d => d.Document == result.PersonId);
            var spouse = State.Value.Disciples.FirstOrDefault(d => d.Document == result.SpouseId);

            var response = await UserApi.MarryAsync(new MarryLeadersDto
            {
                PersonId = result.PersonId,
                SpouseId = result.SpouseId
            });

            if (response?.Success ?? false)
            {
                var personName = person is not null ? $"{person.Name} {person.LastName}" : result.PersonId;
                var spouseName = spouse is not null ? $"{spouse.Name} {spouse.LastName}" : result.SpouseId;
                Snackbar.Add(translator["MarriedSuccessfully", personName, spouseName], Severity.Success);
                Dispatcher.Dispatch(new FetchDisciplesAction { CellId = CellId });
            }
            else
            {
                Snackbar.Add(response?.Details ?? translator["FailedTo", translator["Marry"]], Severity.Error);
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
