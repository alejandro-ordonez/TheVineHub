using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Web.Store.CellAttendances;
using JMMinistry.Web.Store.CellAttendances.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.Ministry.Cells
{
    public partial class CellAttendances
    {

        [Parameter]
        public required int CellId { get; set; }

        [Inject]
        public required IState<CellAttendancesState> State { get; set; }

        [Inject]
        public required IDispatcher Dispatcher { get; set; }

        [Inject]
        public required IDialogService DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dispatcher.Dispatch(new FetchCellAttendancesAction { CellId = CellId });
        }

        async Task OpenAttendanceDetails(CellAttendanceDto attendance)
        {
            var parameters = new DialogParameters<CellAttendanceDialog>()
            {
                {x => x.Attendance, attendance },
                {x => x.CellId, CellId }
            };

            await DialogService.ShowAsync<CellAttendanceDialog>(translator["Attendance", attendance.Date.ToShortDateString()], parameters);
        }
    }
}
