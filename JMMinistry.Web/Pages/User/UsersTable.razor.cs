using JMMinistry.Common.Dtos.User;
using JMMinistry.Web.Api;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JMMinistry.Web.Pages.User
{
    public partial class UsersTable(IUserApi userApi)
    {

        private string _searchString = string.Empty;
        private MudTable<UserInfoDto>? table;

        [Parameter]
        public UsersSearchCriteria? DefaultUserCriteria { get; set; }

        [Parameter]
        public bool Selectable { get; set; } = false;

        [Parameter]
        public bool UseServer { get; set; } = true;

        [Parameter]
        public IList<UserInfoDto> Users { get; set; } = [];

        [Parameter]
        public HashSet<UserInfoDto> Selected { get; set; } = [];

        [Parameter]
        public EventCallback<UserEventArgs> EditUser { get; set; }

        [Parameter]
        public EventCallback<UserEventArgs> DeleteUser { get; set; }

        [Parameter]
        public EventCallback<UserEventArgs> UserDetails { get; set; }

        private bool AnyActions
            => EditUser.HasDelegate || DeleteUser.HasDelegate || UserDetails.HasDelegate;

        private async Task<TableData<UserInfoDto>> UserLoad(TableState state, CancellationToken token)
        {
            var criteria = DefaultUserCriteria ?? new UsersSearchCriteria();

            criteria.Document = _searchString;
            criteria.OrderByMember = state.SortLabel;
            criteria.OrderDirection = state.SortDirection.ToString();
            criteria.Page = state.Page;
            criteria.PageSize = state.PageSize;


            var results = await userApi.GetUserByCriteria(criteria);

            if (!results?.Success ?? false || results == null)
                return new TableData<UserInfoDto>();

            return new TableData<UserInfoDto>
            {
                Items = results?.Data?.Results ?? [],
                TotalItems = results?.Data?.Total ?? 0
            };
        }

        private void OnSearch(string text)
        {
            _searchString = text;
            table?.ReloadServerData();
        }
    }
}
