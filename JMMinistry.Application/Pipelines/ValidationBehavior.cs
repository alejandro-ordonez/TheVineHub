using FluentValidation;
using JMMinistry.Common;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Pipelines
{
    public class ValidationBehavior<TRequest, TResponse>(
        IEnumerable<IValidator<TRequest>> validators,
        ILogger<ValidationBehavior<TRequest, TResponse>> logger) 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("Running validations for request: {RequestName}", typeof(TRequest).Name);

            ArgumentNullException.ThrowIfNull(next);

            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

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
            return await next().ConfigureAwait(false);
        }
    }
}
