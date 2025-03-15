using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
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
        IAuthStateProvider authState, 
        IStringLocalizer<UIStrings> translator, 
        IDialogService dialogService,
        NavigationManager navigationManager
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
        Dictionary<int, IList<PartialUserInfoDto>> Disciples { get; set; } = [];

        bool AddCellOpen { get; set; }
        bool IsBusy { get; set; }

        string? UserId { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            await RefreshCells();

            var state = await authState.GetAuthenticationStateAsync();
            UserId = state.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        async Task RefreshCells()
        {
            var response = await ministryApi.GetAsync();

            if (response?.Success ?? false)
                Cells = response?.Data?.ToDictionary(cell => cell.Id, cell => cell) ?? [];

            foreach(var cellId in Cells.Keys)
            {
                Disciples[cellId] = await FetchDisciples(cellId);
            }

            StateHasChanged();
        }

        async Task OpenAddDisciple(int cellId)
        {
            IsBusy = true;

            var dialog = await dialogService.ShowAsync<AddDisciplesDialog>();
            var result = await dialog.GetReturnValueAsync<DialogResult<HashSet<PartialUserInfoDto>>>();

            if (result is null || result.Data is null)
            {
                IsBusy = false;
                return;
            }

            await AddDisciplesAsync(result.Data, cellId);

            IsBusy = false;
        }

        async Task OpenAddCell()
        {
            IsBusy = true;

            var dialog = await dialogService.ShowAsync<CellDialog>();
            var result = await dialog.GetReturnValueAsync<DialogResult<CreateCellDto>>();

            if (result is null || result.Data is null)
            {
                IsBusy = false;
                return;
            }

            await SubmitAddCell(result.Data);
            IsBusy = false;
        }

        async Task SubmitAddCell(CreateCellDto cellDto)
        {
            var response = await ministryApi.CreateCell(cellDto);

            if (response != null && response.Success && response.Data != null)
                Cells[response.Data.Id] = response.Data;
        }

        async Task AddDisciplesAsync(HashSet<PartialUserInfoDto> disciples, int cellId)
        {
            IsBusy = true;

            if(disciples.Count == 0)
            {
                IsBusy = false;
                return;
            }

            var addDisciples = new AddDisciplesDto
            {
                Documents = [.. disciples.Select(disciple => disciple.Document)],
                CellId = cellId
            };

            var response = await ministryApi.AddDisciples(addDisciples);

            if (response != null && response.Success && response.Data != null)
            {
                Disciples[cellId] = response.Data;
            }

            IsBusy = false;
        }

        async Task<IList<PartialUserInfoDto>> FetchDisciples(int cellId)
        {
            var result = await ministryApi.GetDisciples(cellId);
            return result?.Data ?? [];
        }

        async Task RemoveDisciple(UserEventArgs eventArgs)
        {
            var parameters = new DialogParameters<ConfirmationDialog>
            {
                {x => x.ButtonText, translator["Remove"] },
                {x => x.ContentText, translator["AreYouSure", translator["Remove"], translator["Disciple"], eventArgs.Document] },
                {x => x.Color, Color.Error },
            };

            var dialog = await dialogService.ShowAsync<ConfirmationDialog>(translator["Remove"], parameters);
            var result = await dialog.Result;

            if(!result?.Canceled ?? false)
            {
                var response = await ministryApi.RemoveDiscipleFromCell(eventArgs.CellId, eventArgs.Document);

                if (response?.Success ?? false)
                {
                    Disciples[eventArgs.CellId] = response?.Data ?? [];
                }
            }
        }

        async Task ShowUserDetails(UserEventArgs user)
        {
            var parameters = new DialogParameters<UserDetailsDialog>
            {
                {x => x.Document, user.Document }
            };

            var dialog = await dialogService.ShowAsync<UserDetailsDialog>(translator["Details"], parameters);
            var result = await dialog.GetReturnValueAsync<DialogResult<UserEventArgs>>();

            if (result is null || result.Data is null)
                return;

            switch(result.Option)
            {
                case DialogResultOption.PrimaryButton:
                    navigationManager.NavigateTo($"{Routes.User}/{user.Document}");
                    break;

                case DialogResultOption.SecondaryButton:
                    await RemoveDisciple(result.Data);
                    break;
            };

            
        }
    }
}
