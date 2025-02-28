using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Web.Api;
using JMMinistry.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Security.Claims;

namespace JMMinistry.Web.Pages.Ministry
{
    public partial class Ministry(IMinistryApi ministryApi, IAuthStateProvider authState)
    {
        IList<CellDto> Cells { get; set; } = [];

        bool AddDiscipleOpen { get; set; }
        bool AddCellOpen { get; set; }
        bool IsBusy { get; set; }

        int? TargetCellId { get; set; }

        UsersSearchCriteria? InitialCriteria { get; set; }

        [SupplyParameterFromForm]
        CreateCellDto CreateCellDto { get; set; } = new CreateCellDto();
        MudForm? cellForm;

        protected override async Task OnInitializedAsync()
        {
            var response = await ministryApi.GetAsync();

            if (response?.Success ?? false)
                Cells = response?.Data ?? [];

            var state = await authState.GetAuthenticationStateAsync();
            var id = state.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            InitialCriteria = new UsersSearchCriteria
            {
                Requestor = id?.Value,
                MinistryStatus = [MinistryStatus.Unknown, MinistryStatus.Gained]
            };
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
            AddCellOpen = false;
        }

        void Cancel()
        {
            AddCellOpen = false;
            AddDiscipleOpen = false;
        }
    }
}
