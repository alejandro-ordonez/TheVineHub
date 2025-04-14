using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Web.Api;
using JMMinistry.Web.Pages.User;
using JMMinistry.Web.Shared.Components;
using JMMinistry.Web.Store.CellsUseCase;
using JMMinistry.Web.Store.CellsUseCase.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.Ministry.Cells
{
    public partial class Cells
    {
        [Inject]
        public required IState<CellsState> CellsState { get; set; }

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
        }

        async Task OpenAddCell()
        {
            var dialog = await DialogService.ShowAsync<CellDialog>();
            var result = await dialog.GetReturnValueAsync<DialogResult<CreateCellDto>>();

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
