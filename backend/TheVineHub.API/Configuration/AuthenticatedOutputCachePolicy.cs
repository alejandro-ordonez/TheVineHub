using Microsoft.AspNetCore.OutputCaching;

namespace TheVineHub.API.Configuration;

/// <summary>
/// OutputCache policy that allows caching responses for authenticated endpoints
/// that return the same data regardless of the caller.
/// </summary>
public sealed class AuthenticatedOutputCachePolicy : IOutputCachePolicy
{
    public ValueTask CacheRequestAsync(OutputCacheContext context, CancellationToken ct)
    {
        var request = context.HttpContext.Request;
        var isGetOrHead = HttpMethods.IsGet(request.Method) || HttpMethods.IsHead(request.Method);

        context.EnableOutputCaching = true;
        context.AllowCacheLookup = isGetOrHead;
        context.AllowCacheStorage = isGetOrHead;
        context.AllowLocking = true;

        // Vary by Authorization header to ensure different users/states get different cache entries
        context.CacheVaryByRules.HeaderNames = "Authorization";
        context.CacheVaryByRules.RouteValueNames = "*";

        return ValueTask.CompletedTask;
    }

    public ValueTask ServeFromCacheAsync(OutputCacheContext context, CancellationToken ct)
        => ValueTask.CompletedTask;

    public ValueTask ServeResponseAsync(OutputCacheContext context, CancellationToken ct)
    {
        // Only allow caching for successful responses
        var response = context.HttpContext.Response;
        if (response.StatusCode != StatusCodes.Status200OK)
        {
            context.AllowCacheStorage = false;
            return ValueTask.CompletedTask;
        }

        context.AllowCacheStorage = true;
        return ValueTask.CompletedTask;
    }
}
