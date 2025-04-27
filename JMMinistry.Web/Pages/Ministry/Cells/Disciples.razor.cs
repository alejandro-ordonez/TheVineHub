using Fluxor;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Pages.User;
using JMMinistry.Web.Shared.Components;
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

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        async Task OpenAddDisciple()
        {
            var dialog = await DialogService.ShowAsync<AddDisciplesDialog>();
            var result = await dialog.GetReturnValueAsync<DialogResult<HashSet<PartialUserInfoDto>>>();

            if (result is null || result.Data is null)
                return;

            Dispatcher.Dispatch(new AddDisciplesAction { CellId = CellId, Documents = result.Data.Select(user => user.Document).ToList() });
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
