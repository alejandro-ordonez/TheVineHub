using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Users.ImportUsers
{
    public class ImportUsersEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/users/import", async (HttpRequest request, IMediator mediator) =>
            {
                if (!request.HasFormContentType || request.Form.Files.Count == 0)
                    return Results.BadRequest("File not submitted");

                var formFile = request.Form.Files[0];
                var result = await mediator.Send(new ImportUsersCommand { File = formFile });
                return Results.Ok(result);
            })
            .WithName("ImportUsers")
            .WithTags("Users")
            .RequireAuthorization();
        }
    }
}
