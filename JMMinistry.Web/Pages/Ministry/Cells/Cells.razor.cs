using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Web.Shared.Components;
using JMMinistry.Web.Store.CellUseCase.Actions;
using JMMinistry.Web.Store.MinistryUseCase;
using JMMinistry.Web.Store.MinistryUseCase.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.Ministry.Cells
{
    public partial class Cells
    {
        [Inject]
        public required IState<MinistryState> CellsState { get; set; }

        [Inject]
        public required IDispatcher Dispatcher { get; set; }

        [Inject]
        public required IDialogService DialogService { get; set; }

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher?.Dispatch(new FetchCellsAction());
            // Reset the selected cell when coming back to this 
            Dispatcher?.Dispatch(new ResetCellAction());
        }

        async Task OpenAddCell()
        {
            var parameters = new DialogParameters<CellDialog>
            {
                {x => x.PrimaryButtonText, translator["Add"] }
            };

            var dialog = await DialogService.ShowAsync<CellDialog>(translator["RegisterCell"], parameters);
            var result = await dialog.GetReturnValueAsync<DialogResult<CellDto>>();

            if (result?.Data is null)
                return;

            Dispatcher.Dispatch(new CreateCellAction(result.Data));
        }

        void OpenCellDetails(int cellId)
        {
            NavigationManager?.NavigateTo($"{Routes.CellDetails}/{cellId}");
        }
    }
}
