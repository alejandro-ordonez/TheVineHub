using JMMinistry.Common.Dtos.User;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.User
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
        public EventCallback<UserEventArgs> EditUser { get; set; }

        [Parameter]
        public EventCallback<UserEventArgs> DeleteUser { get; set; }

        [Parameter]
        public EventCallback<UserEventArgs> UserDetails { get; set; }

        [Parameter]
        public required FetchUsers FetchUsers { get; set; }

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
    }
}
