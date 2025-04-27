using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using static JMMinistry.Web.Shared.Constants;

namespace JMMinistry.Web.Extensions
{
    public static class CultureExtensions
    {
        public async static Task SetDefaultUICulture(this WebAssemblyHost host)
        {
            // 1. Read the ILocalStorageService to read the LocalStorage
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();

            // 2. Read the current value for the Culture from the
            // LocalStorage  

            var result = await localStorage.GetItemAsync<string>(CurrentCulture);
            CultureInfo culture;
            if (result != null)
                // 3.a. Set the selected Culture
                culture = new CultureInfo(result);
            else
                // 3.b. else the default culture will be en-US
                culture = new CultureInfo(DefaultCulture);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
