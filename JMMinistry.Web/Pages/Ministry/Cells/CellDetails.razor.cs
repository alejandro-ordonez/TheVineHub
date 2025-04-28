using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Web.Shared.Components;
using JMMinistry.Web.Store.CellUseCase;
using JMMinistry.Web.Store.CellUseCase.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.Ministry.Cells
{
    public partial class CellDetails
    {
        [Parameter]
        public int CellId { get; set; }

        [Inject]
        IState<CellState>? State { get; set; }

        [Inject]
        IDispatcher? Dispatcher { get; set; }

        [Inject]
        IDialogService? DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dispatcher?.Dispatch(new FetchCellAction { CellId = CellId });
        }

        async Task EditCellDetails()
        {
            var parameters = new DialogParameters<CellDialog>
            {
                {x => x.PrimaryButtonText, translator["Update"] }
            };

            var dialog = await dialogService.ShowAsync<CellDialog>(translator["Edit"], parameters);
            var result = await dialog.GetReturnValueAsync<DialogResult<CellDto>>();



            if (result is null || result.Data is null)
                return;

            Dispatcher?.Dispatch(new UpdateCellAction { Cell = result.Data });
        }
    }
}
