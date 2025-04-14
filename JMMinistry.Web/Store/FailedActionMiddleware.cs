using Fluxor;
using JMMinistry.Common.Resources;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace JMMinistry.Web.Store
{
    public class FailedActionMiddleware(ISnackbar snackbar, IStringLocalizer<UIStrings> translator) : Middleware
    {
        public override void BeforeDispatch(object action)
        {
            if(action.GetType().IsGenericType && action.GetType().GetGenericTypeDefinition() == typeof(FailedAction<>))
            {
                var errorKeyProperty = action.GetType().GetProperty(nameof(FailedAction<object>.ErrorKey));
                var errorKey = errorKeyProperty?.GetValue(action);

                snackbar.Add(translator[errorKey?.ToString() ?? "Unknown"], Severity.Error);
            }
        }
    }
}
