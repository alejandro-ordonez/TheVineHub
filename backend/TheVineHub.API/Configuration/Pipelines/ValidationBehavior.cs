using FluentValidation;
using Mediator;
using Microsoft.Extensions.Logging;

namespace TheVineHub.API.Configuration.Pipelines
{
    public class ValidationBehavior<TRequest, TResponse>(
        IEnumerable<IValidator<TRequest>> validators,
        ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IMessage
    {
        public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("Running validations for request: {RequestName}", typeof(TRequest).Name);

            ArgumentNullException.ThrowIfNull(next);

            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(message);

                var validationResults = await Task.WhenAll(
                    validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

                var failures = validationResults
                    .Where(r => r.Errors.Count > 0)
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Count > 0)
                    throw new ValidationException(failures);
            }

            logger.LogInformation("Validations succeeded");
            return await next(message, cancellationToken).ConfigureAwait(false);
        }
    }
}
