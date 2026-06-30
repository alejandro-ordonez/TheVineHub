using JMMinistry.Application.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Authentication;

namespace JMMinistry.Application.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new Response<object>
            {
                Details = $"Request: {httpContext.Request.Path}"
            };

            if (exception is FluentValidation.ValidationException fluentException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Details = "One or more validation errors occurred.";
                response.Errors = fluentException.Errors.Select(error => error.ErrorMessage).ToArray();
            }

            else if (exception is ArgumentException || exception is AuthenticationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Details = "Your request was incorrect";
                response.Errors = [exception.Message];
            }

            else if (exception is NotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Details = "The requested resource was not found";
                response.Errors = [exception.Message];
            }

            else if (exception is NotAuthorizedException)
            {
                response.StatusCode = StatusCodes.Status401Unauthorized;
                response.Details = "Not authorize to see this resource";
                response.Errors = [exception.Message];
            }

            else
                response.Errors = [exception.Message];


            logger.LogError("Exception occurred: {ExceptionName}", exception.GetType().Name);

            httpContext.Response.StatusCode = response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(response);
            return true;
        }
    }
}
