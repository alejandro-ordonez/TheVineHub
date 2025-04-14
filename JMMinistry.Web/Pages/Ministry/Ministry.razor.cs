using Fluxor;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Resources;
using JMMinistry.Web.Api;
using JMMinistry.Web.Pages.User;
using JMMinistry.Web.Services;
using JMMinistry.Web.Shared.Components;
using JMMinistry.Web.Store.PageUseCase;
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
        IDispatcher dispatcher
        )
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            dispatcher.Dispatch(new SetTitleAction { Title = translator["MyMinistry"] });
        }

        Dictionary<int, CellDto> Cells { get; set; } = [];
        Dictionary<int, IList<PartialUserInfoDto>> Disciples { get; set; } = [];

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

        async Task<IList<PartialUserInfoDto>> FetchDisciples(int cellId)
        {
            var result = await ministryApi.GetDisciples(cellId);
            return result?.Data ?? [];
        }
    }
}
