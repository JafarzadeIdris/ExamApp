using Exam.Application.Abstractions.Error;
using Exam.Application.Errors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Exam.Application.Behaviors
{
    public class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next(cancellationToken);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "❌ Exception occurred while handling {RequestType}: {Message}", typeof(TRequest).Name, exception.Message);
                var failureResult = Result.Failure<Guid, IDomainError>(new DomainError(exception.Message));

                if (failureResult is TResponse response)
                    return response;
                else
                    throw new InvalidOperationException($"The response type {typeof(TResponse).Name} is not compatible with the failure result.");
            }
        }

    }
}
