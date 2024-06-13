using JMMinistry.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
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
            // execute the request
            await _next(context);

            if (context.Response.ContentType != "application/json")
                return;

            var currentBody = JsonSerializer.DeserializeAsync<object>(context.Response.Body);

            var result = new Response<object>
            {
                Data = currentBody,
                Success = true,
                StatusCode = context.Response.StatusCode,
                Details = $"Operation success: {context.Request.Path}"
            };

            _logger.LogInformation("The operation was completed with status: {status}", context.Response.StatusCode);

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
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
