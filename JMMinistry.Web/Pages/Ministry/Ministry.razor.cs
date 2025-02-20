using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.Ministry
{
    public partial class Ministry(IMinistryApi ministryApi)
    {
        IList<CellDto> Cells { get; set; } = [];

        bool AddDiscipleOpen { get; set; }
        bool AddCellOpen { get; set; }
        bool IsBusy { get; set; }

        int? TargetCellId { get; set; }

        [SupplyParameterFromForm]
        CreateCellDto CreateCellDto { get; set; } = new CreateCellDto();
        MudForm? cellForm;

        IList<UserInfoDto> SearchResults { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var response = await ministryApi.GetAsync();

            if (response?.Success ?? false)
                Cells = response?.Data ?? [];
        }

        void OpenAddDisciple(int cellId)
        {
            TargetCellId = cellId;
            AddDiscipleOpen = true;
        }

        void OpenAddCell()
        {
            AddCellOpen = true;
        }

        async Task SubmitAddCell()
        {
            IsBusy = true;
            var response = await ministryApi.CreateCell(CreateCellDto);

            if (response != null && response.Success && response.Data != null)
                Cells.Add(response.Data);

            IsBusy = false;
        }

        void Cancel()
        {
            AddCellOpen = false;
            AddDiscipleOpen = false;
        }

    }
}
