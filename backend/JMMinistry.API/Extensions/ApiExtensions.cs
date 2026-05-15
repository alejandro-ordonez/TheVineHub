using JMMinistry.Common;
using Microsoft.OpenApi;
using System.Security.Claims;

namespace JMMinistry.API.Extensions
{
    public static class ApiExtensions
    {

        public static string? GetDocumentClaim(this HttpContext httpContext)
        {
            var documentClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)
                               ?? httpContext.User.Claims.FirstOrDefault(claim => claim.Type == "sub");
            var document = documentClaim?.Value;

            if (document != null && document.StartsWith("user:"))
                document = document.Substring(5);

            return document;
        }

        public static IEnumerable<string> GetRoles(this HttpContext httpContext)
        {
            var roleClaims = httpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.Role || claim.Type == "roles");
            var roles = roleClaims.Select(claim => claim.Value);

            return roles;
        }

        public static bool UserHasRole(this HttpContext httpContext, Roles role)
        {
            var roleString = role.ToString();
            return httpContext.User.Claims.Any(
                claim => (claim.Type == ClaimTypes.Role || claim.Type == "roles") && claim.Value == roleString
                );
        }
    }
}
