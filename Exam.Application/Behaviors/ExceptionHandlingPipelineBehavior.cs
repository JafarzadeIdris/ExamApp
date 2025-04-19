using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Exam.Application.Behaviors
{
    public class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> _logger = logger;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "❌ Exception occurred while handling {RequestType}: {Message}",
                    typeof(TRequest).Name,
                    ex.Message);

                var failureResult = MapExceptionToFailureResult(ex);

                if (failureResult is TResponse response)
                {
                    _logger.LogWarning(" Returning failure result for {RequestType} as {ResponseType}",
                        typeof(TRequest).Name,
                        typeof(TResponse).Name);

                    return response;
                }

                _logger.LogCritical(" Could not cast failure result to expected type {TResponse}", typeof(TResponse).Name);
                throw new InvalidCastException($"Failed to cast error result to expected response type: {typeof(TResponse).Name}");
            }
        }

        private object? MapExceptionToFailureResult(Exception ex)
        {
            return ex switch
            {
                ValidationException validationEx => Result.Failure<Unit>(validationEx.Message),

                _ => null 
            };
        }
    }

}
