using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Pages.User.Components;
using JMMinistry.Web.Store.CellAttendances.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.Ministry.Cells
{
    public partial class CellAttendanceDialog
    {
        [CascadingParameter]
        protected IMudDialogInstance? MudDialog { get; set; }

        [Parameter]
        public required CellAttendanceDto Attendance { get; set; }

        [Parameter]
        public required int CellId { get; set; }

        [Inject]
        public required IDispatcher Dispatcher { get; set; }

        private bool IsEditing { get; set; }
        private string? EditNotes { get; set; }
        private DateTime? EditDate { get; set; }

        private Dictionary<string, UserCard> UserCards { get; set; } = [];

        private List<PartialUserInfoDto> AllDisciples => [.. Attendance.Attendees, .. Attendance.MissingAttendees];

        private HashSet<string> SelectedDocuments => [.. Attendance.Attendees.Select(a => a.Document)];

#pragma warning disable S2376
        UserCard? ComponentRef { set => UserCards[value!.User.Document] = value; }
#pragma warning restore S2376

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender && MudDialog is not null)
            {
                var options = MudDialog.Options with
                {
                    FullWidth = true,
                    MaxWidth = MaxWidth.Large
                };
                MudDialog.SetOptionsAsync(options);
            }
        }

        void EnterEditMode()
        {
            IsEditing = true;
            EditNotes = Attendance.Notes;
            EditDate = Attendance.Date;
            UserCards.Clear();
        }

        void CancelEdit()
        {
            IsEditing = false;
        }

        void Save()
        {
            var selectedDocs = UserCards
                .Where(card => card.Value.Selected)
                .Select(card => card.Key)
                .ToList();

            if (selectedDocs.Count == 0)
                return;

            Dispatcher.Dispatch(new UpdateCellAttendanceAction
            {
                CellId = CellId,
                AttendanceId = Attendance.Id,
                Documents = selectedDocs,
                Notes = EditNotes,
                Date = EditDate ?? Attendance.Date
            });

            MudDialog?.Close();
        }

        void Cancel() => MudDialog?.Cancel();
    }
}
