using Fluxor;
using JMMinistry.Web.Store.CellUseCase;
using JMMinistry.Web.Store.CellUseCase.Actions;
using Microsoft.AspNetCore.Components;

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

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dispatcher?.Dispatch(new FetchCellAction {  CellId = CellId });
        }
    }
}
