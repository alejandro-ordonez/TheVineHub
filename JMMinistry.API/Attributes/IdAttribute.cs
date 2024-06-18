using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace JMMinistry.API.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class IdAttribute: Attribute, IBindingSourceMetadata, IModelBinder
    {
        public BindingSource BindingSource => BindingSource.Header;

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var documentClaim = bindingContext.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            var document = documentClaim?.Value;

            if (!string.IsNullOrEmpty(document))
                bindingContext.Result = ModelBindingResult.Success(document);

            else
                bindingContext.Result = ModelBindingResult.Failed();

            return Task.CompletedTask;
        }
    }
}
