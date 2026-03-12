using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using JMMinistry.Web.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

using JMMinistry.Web.Pages.User.Dialogs;

namespace JMMinistry.Web.Pages.User.Components
{
    public partial class UsersTable
    {

        private string _searchString = string.Empty;
        private MudTable<PartialUserInfoDto>? table;

        [Parameter]
        public bool Selectable { get; set; } = false;

        [Parameter]
        public HashSet<PartialUserInfoDto> Selected { get; set; } = [];

        [Parameter]
        public EventCallback<HashSet<PartialUserInfoDto>> SelectedChanged { get; set; }

        [Parameter]
        public EventCallback<UserEventArgs> EditUser { get; set; }

        [Parameter]
        public EventCallback<UserEventArgs> DeleteUser { get; set; }

        [Parameter]
        public EventCallback<UserEventArgs> UserDetails { get; set; }

        [Parameter]
        public required FetchUsers FetchUsers { get; set; }

        [Inject]
        public required IDialogService DialogService { get; set; }

        [Inject]
        public required IUserApi UserApi { get; set; }

        private bool AnyActions
            => EditUser.HasDelegate || DeleteUser.HasDelegate || UserDetails.HasDelegate;

        public async Task RefreshData()
        {
            await table!.ReloadServerData();
        }

        private async Task<TableData<PartialUserInfoDto>> UserLoad(TableState state, CancellationToken token)
        {
            var users = await FetchUsers(state, _searchString);

            if (users == null)
                return new TableData<PartialUserInfoDto>();

            return new TableData<PartialUserInfoDto>
            {
                Items = users?.Results ?? [],
                TotalItems = users?.Total ?? 0
            };
        }

        private async Task OnSelectedItemsChanged(HashSet<PartialUserInfoDto> items)
        {
            Selected = items;
            await SelectedChanged.InvokeAsync(items);
        }

        private void OnSearch(string text)
        {
            _searchString = text;
            table?.ReloadServerData();
        }

        async Task RowClicked(TableRowClickEventArgs<PartialUserInfoDto> args)
        {
            if (!UserDetails.HasDelegate || args.Item is null)
                return;

            await UserDetails.InvokeAsync(new UserEventArgs { CellId = 0, Document = args.Item.Document });
        }

        async Task OpenAddUser()
        {
            var dialog = await DialogService.ShowAsync<AddUserDialog>(_translator["AddUser"]);
            var result = await dialog.GetReturnValueAsync<DialogResult<CreateUserInfoDto>>();

            if (result?.Data is null)
                return;

            var response = result.Data.IsUpdate
                ? await UserApi.UpdateUser(result.Data)
                : await UserApi.CreateUser(result.Data);

            if (response?.Success ?? false)
            {
                await RefreshData();
            }
        }
    }
}
