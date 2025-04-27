using JMMinistry.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace JMMinistry.API.Middleware
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseMiddleware> _logger;

        public ResponseMiddleware(RequestDelegate next, ILogger<ResponseMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Processing request for: {Request}", context.Request.Path);

            var originalResponseBody = context.Response.Body;
            using (var swapStream = new MemoryStream())
            {
                try
                {
                    context.Response.Body = swapStream;

                    // Execute the next middleware in the pipeline
                    await _next(context);

                    swapStream.Seek(0, SeekOrigin.Begin);

                    object? currentBody;

                    string[] contentTypes = [MediaTypeNames.Application.Json, MediaTypeNames.Text.Plain];

                    if (!contentTypes.Any(contentType => context.Response.ContentType?.Contains(contentType) ?? false) ||
                        context.Response.StatusCode == StatusCodes.Status204NoContent)
                        return;

                    if (context.Response.ContentType?.Contains(MediaTypeNames.Text.Plain) ?? false)
                    {
                        using var reader = new StreamReader(swapStream, Encoding.UTF8);
                        currentBody = await reader.ReadToEndAsync();
                        swapStream.Seek(0, SeekOrigin.Begin);
                    }

                    else if (swapStream.Length == 0)
                        currentBody = null;

                    else
                        currentBody = await JsonSerializer.DeserializeAsync<object>(swapStream);

                    // Gets here when token expired
                    if(context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                    {
                        swapStream.Seek(0, SeekOrigin.Begin);
                        await swapStream.CopyToAsync(originalResponseBody);
                    }

                    else
                    {
                        var result = new Response<object>
                        {
                            Data = currentBody,
                            Success = true,
                            StatusCode = context.Response.StatusCode,
                            Details = $"Operation success: {context.Request.Path}"
                        };

                        await JsonSerializer.SerializeAsync(originalResponseBody, result);
                    }
                }

                finally
                {
                    context.Response.Body = originalResponseBody;
                }
                
            }                      
            
            _logger.LogInformation("The operation was completed with status: {Status}", context.Response.StatusCode);
        }
    }

    public static class ResponseMiddlewareExtensions
    {
        public static void UseResponseMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ResponseMiddleware>();
        }
    }
}
