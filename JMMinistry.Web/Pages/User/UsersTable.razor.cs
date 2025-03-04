using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.User
{
    public partial class UsersTable
    {

        private string _searchString = string.Empty;
        private MudTable<UserInfoDto>? table;

        [Parameter]
        public bool Selectable { get; set; } = false;

        [Parameter]
        public HashSet<UserInfoDto> Selected { get; set; } = [];

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

        private async Task<TableData<UserInfoDto>> UserLoad(TableState state, CancellationToken token)
        {
            var users = await FetchUsers(state, _searchString);

            if(users == null)
                return new TableData<UserInfoDto>();

            return new TableData<UserInfoDto>
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
    }
}
