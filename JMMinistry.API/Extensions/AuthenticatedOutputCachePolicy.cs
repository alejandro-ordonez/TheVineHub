using Microsoft.AspNetCore.OutputCaching;

namespace JMMinistry.API.Extensions;

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
        context.CacheVaryByRules.RouteValueNames = "*";

        return ValueTask.CompletedTask;
    }

    public ValueTask ServeFromCacheAsync(OutputCacheContext context, CancellationToken ct)
        => ValueTask.CompletedTask;

    public ValueTask ServeResponseAsync(OutputCacheContext context, CancellationToken ct)
    {
        context.AllowCacheStorage = true;
        return ValueTask.CompletedTask;
    }
}
