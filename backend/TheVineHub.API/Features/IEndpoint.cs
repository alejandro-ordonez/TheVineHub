using Microsoft.AspNetCore.Routing;

namespace TheVineHub.API.Features
{
    /// <summary>
    /// Interface implemented by all vertical slice endpoint classes.
    /// Each implementation maps one or more minimal API routes into the given IEndpointRouteBuilder.
    /// </summary>
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
