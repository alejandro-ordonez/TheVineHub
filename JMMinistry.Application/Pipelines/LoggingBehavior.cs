using MediatR;
using Microsoft.Extensions.Logging;

namespace JMMinistry.Application.Pipelines
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("Executing request for: {Request name}", typeof(TRequest).Name);
            var response = await next();
            logger.LogInformation("Execution completed");

            return response;
        }
    }
}
