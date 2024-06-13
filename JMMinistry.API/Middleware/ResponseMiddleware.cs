using JMMinistry.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace JMMinistry.API.Middleware
{
    public class ResponseMiddleware(RequestDelegate next, ILogger<ResponseMiddleware> logger): IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            logger.LogInformation("Processing request for: {request}", context.Request.Path);
            // execute the request
            await next(context);

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
