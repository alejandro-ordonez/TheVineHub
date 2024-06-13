using JMMinistry.Common;
using Newtonsoft.Json;
using System.Net;

namespace JMMinistry.API.Middleware
{
    public class ResponseMiddleware(RequestDelegate next, ILogger<ResponseMiddleware> logger)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var currentBody = httpContext.Response.Body;

                using (var memoryStream = new MemoryStream())
                {
                    //set the current response to the memoryStream.
                    httpContext.Response.Body = memoryStream;

                    await next(httpContext);

                    //reset the body 
                    httpContext.Response.Body = currentBody;
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                    var objResult = JsonConvert.DeserializeObject(readToEnd);

                    var result = new Response<object>
                    {
                        Data = objResult,
                        Success = true,
                        StatusCode = httpContext.Response.StatusCode,
                        Details = $"Operation success: {httpContext.Request.Path}"
                    };

                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));
                }
            }
            catch (Exception)
            {
                if (httpContext.Response.HasStarted)
                {
                    logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }
                return;
            }
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
