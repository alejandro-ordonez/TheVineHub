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
                response.Details = "One or more validation errors occurred.";
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                response.Errors = fluentException.Errors.Select(error => error.ErrorMessage).ToArray();
            }

            if (exception is ArgumentException || exception is AuthenticationException)
            {
                response.Details = "Your request was incorrect";
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                response.Errors = [exception.Message];
            }

            else
                response.Errors = [exception.Message];

            logger.LogError("Exception occurred: {ExceptionName}", exception.GetType().Name);

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
