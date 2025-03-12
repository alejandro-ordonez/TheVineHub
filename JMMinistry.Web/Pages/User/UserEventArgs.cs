using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using MudBlazor;

namespace JMMinistry.Web.Pages.User
{
    public class UserEventArgs: EventArgs
    {
        public required int CellId { get; set; }
        public required string Document { get; set; }
    }

    public delegate Task<PagedResponse<PartialUserInfoDto>> FetchUsers(TableState state, string searchString);
}
