using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TheVineHub.API.Configuration;
using TheVineHub.API.Configuration.Exceptions;

namespace TheVineHub.API.Features.Users.Photos
{
    public class PhotosEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users").RequireAuthorization();

            group.MapGet("/photo/upload-url", async (string fileName, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetPhotoUploadUrlCommand { FileName = fileName });
                return Results.Ok(result);
            })
            .WithName("GetPhotoUploadUrl");

            group.MapDelete("/{document}/photo", async (string document, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                await mediator.Send(new DeletePhotoCommand
                {
                    RequestorId = requestorId,
                    Document = document
                });
                return Results.Ok(new { });
            })
            .WithName("DeletePhoto");

            group.MapPost("/photo/upload-temp", async (HttpRequest request, IMediator mediator) =>
            {
                if (!request.HasFormContentType || request.Form.Files.Count == 0)
                    return Results.BadRequest("Photo file not submitted");

                var file = request.Form.Files[0];
                var result = await mediator.Send(new UploadTempPhotoCommand { ImageStream = file.OpenReadStream() });
                return Results.Ok(result);
            })
            .WithName("UploadTempPhoto");

            group.MapPost("/{document}/photo/assign-temp", async (string document, string tempId, HttpContext httpContext, IMediator mediator) =>
            {
                var requestorId = httpContext.GetDocumentClaim() ?? throw new MissingInTokenException();
                var result = await mediator.Send(new AssignTempPhotoCommand
                {
                    RequestorId = requestorId,
                    Document = document,
                    TempId = tempId
                });
                return Results.Ok(result);
            })
            .WithName("AssignTempPhoto");
        }
    }
}
