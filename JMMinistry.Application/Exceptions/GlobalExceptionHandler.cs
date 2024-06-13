using JMMinistry.Common;
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
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                
                response.Details = "One or more validation errors occurred.";
                response.Errors = fluentException.Errors.Select(error => error.ErrorMessage).ToArray();
            }

            else if (exception is ArgumentException || exception is AuthenticationException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                response.Details = "Your request was incorrect";
                response.Errors = [exception.Message];
            }

            else
                response.Errors = [exception.Message];

            response.StatusCode = httpContext.Response.StatusCode;

            logger.LogError("Exception occurred: {ExceptionName}", exception.GetType().Name);

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
