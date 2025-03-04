using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Common.Resources;
using JMMinistry.Web.Api;
using JMMinistry.Web.Pages.User;
using JMMinistry.Web.Services;
using JMMinistry.Web.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using System.Security.Claims;

namespace JMMinistry.Web.Pages.Ministry
{
    public partial class Ministry(
        IMinistryApi ministryApi, 
        IUserApi userApi,
        IAuthStateProvider authState, 
        IStringLocalizer<UIStrings> translator, 
        IDialogService dialogService
        )
    {
        protected override void OnInitialized()
        {
            if(PageTitle != null)
            {
                PageTitle = translator[nameof(Ministry)];
                StateHasChanged();
            }
        }

        [CascadingParameter]
        public string? PageTitle { get; set; }
        Dictionary<int, CellDto> Cells { get; set; } = [];
        Dictionary<int, UsersTable> CellsTables { get; set; } = [];

        bool AddDiscipleOpen { get; set; }
        bool AddCellOpen { get; set; }
        bool IsBusy { get; set; }

        int TargetCellId { get; set; }

        string? UserId { get; set; }

        [SupplyParameterFromForm]
        CreateCellDto CreateCellDto { get; set; } = new CreateCellDto();
        MudForm? cellForm;

        public HashSet<UserInfoDto> DisciplesSelected { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await RefreshCells();

            var state = await authState.GetAuthenticationStateAsync();
            UserId = state.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        async Task RefreshCells()
        {
            var response = await ministryApi.GetAsync();

            if (response?.Success ?? false)
                Cells = response?.Data?.ToDictionary(cell => cell.Id, cell => cell) ?? [];
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
                Cells[response.Data.Id] = response.Data;

            IsBusy = false;
            AddCellOpen = false;
        }

        async Task SubmitAddDisciples()
        {
            IsBusy = true;

            if(DisciplesSelected.Count == 0)
            {
                IsBusy = false;
                AddDiscipleOpen = false;
                return;
            }

            var addDisciples = new AddDisciplesDto
            {
                Documents = [.. DisciplesSelected.Select(disciple => disciple.Document)],
                CellId = TargetCellId
            };

            var response = await ministryApi.AddDisciples(addDisciples);

            if (response != null && response.Success && response.Data != null)
            {
                Cells[response.Data.Id] = response.Data;

                if(CellsTables.TryGetValue(response.Data.Id, out UsersTable? value))
                    await value.RefreshData();
            }

            IsBusy = false;
            AddDiscipleOpen = false;
        }

        void Cancel()
        {
            AddCellOpen = false;
            AddDiscipleOpen = false;
            IsBusy = false;
        }

        Task<PagedResponse<UserInfoDto>> DummyFetchUsers(int cellId)
        {
            IList<UserInfoDto> users = [];

            if (Cells.TryGetValue(cellId, out var cell))
                users = cell.Disciples;

            var pagedResponse = new PagedResponse<UserInfoDto>
            {
                Results = users,
                Total = users.Count
            };

            return Task.FromResult(pagedResponse);
        }

        async Task<PagedResponse<UserInfoDto>> FetchUsers(TableState state, string searchString)
        {
            var criteria = new UsersSearchCriteria
            {
                Requestor = UserId,
                MinistryStatus = [MinistryStatus.Unknown, MinistryStatus.Gained],
                Document = searchString,
                OrderByMember = state.SortLabel,
                OrderDirection = state.SortDirection.ToString(),
                Page = state.Page,
                PageSize = state.PageSize
            };


            var results = await userApi.GetUserByCriteria(criteria);

            PagedResponse<UserInfoDto> pagedResponse;

            if (!results?.Success ?? true)
                pagedResponse = new PagedResponse<UserInfoDto>();

            else
                pagedResponse = results?.Data ?? new PagedResponse<UserInfoDto>();

            return pagedResponse;
        }


        async Task EditDisciple(UserEventArgs eventArgs)
        {

        }

        async Task RemoveDisciple(UserEventArgs eventArgs)
        {
            var parameters = new DialogParameters<Dialog>
            {
                {x => x.ButtonText, translator["Remove"] },
                {x => x.ContentText, translator["AreYouSure", translator["Remove"], translator["Disciple"], eventArgs.Document] },
                {x => x.Color, Color.Error },
            };

            var dialog = await dialogService.ShowAsync<Dialog>(translator["Remove"], parameters);
            var result = await dialog.Result;

            if(!result?.Canceled ?? false)
            {
                var response = await ministryApi.RemoveDiscipleFromCell(eventArgs.CellId, eventArgs.Document);

                if (response?.Success ?? false)
                {
                    await RefreshCells();

                    if (CellsTables.TryGetValue(eventArgs.CellId, out UsersTable? value))
                        await value.RefreshData();
                }
            }
        }
    }
}
