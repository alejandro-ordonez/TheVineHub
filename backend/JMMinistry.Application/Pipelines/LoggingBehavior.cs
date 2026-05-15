using Mediator;
using Microsoft.Extensions.Logging;

namespace JMMinistry.Application.Pipelines
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IMessage
    {
        public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("Executing request for: {Request name}", typeof(TRequest).Name);
            var response = await next(message, cancellationToken);
            logger.LogInformation("Execution completed");

            return response;
        }
    }
}
