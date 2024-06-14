using JMMinistry.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
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
            _logger.LogInformation("Processing request for: {request}", context.Request.Path);

            using var swapStream = new MemoryStream();

            var originalResponseBody = context.Response.Body;
            context.Response.Body = swapStream;

            // Execute the next middleware in the pipeline
            await _next(context);

            if (!context.Response.ContentType?.Contains(MediaTypeNames.Application.Json) ?? true)
                return;

            // Rewind the MemoryStream to read its content
            swapStream.Seek(0, SeekOrigin.Begin);

            var currentBody = await JsonSerializer.DeserializeAsync<object>(swapStream);

            var result = new Response<object>
            {
                Data = currentBody,
                Success = true,
                StatusCode = context.Response.StatusCode,
                Details = $"Operation success: {context.Request.Path}"
            };

            // Restore the original response body
            await JsonSerializer.SerializeAsync(originalResponseBody, result);
            context.Response.Body = originalResponseBody;
                     
            
            _logger.LogInformation("The operation was completed with status: {status}", context.Response.StatusCode);
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
