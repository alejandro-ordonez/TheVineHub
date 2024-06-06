using Microsoft.AspNetCore.Components;

namespace JMMinistry.Web.Shared.Components
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager?.NavigateTo("/auth");
        }
    }
}
