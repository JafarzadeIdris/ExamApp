using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Exam.Application.Behaviors
{
    public class ExceptionHandlingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull, IRequest<TResponse>
     where TResponse : notnull
    {
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
                var failureResult = MapExceptionToFailureResult(ex);

                if (failureResult is TResponse response)
                    return response;

                throw new InvalidCastException($"Failed to cast error result to expected response type: {typeof(TResponse).Name}");
            }
        }

        private object? MapExceptionToFailureResult(Exception ex)
        {
            return ex switch
            {
                ValidationException validationEx => Result.Failure<Unit>(
                   ex.Message),

                _ => null // Optional: log unknown errors here
                          // Or return a generic unexpected DomainError if you uncomment this:
                          // => Result.Failure<Guid, IDomainError>(DomainError.UnExpected($"Unexpected error: {ex.Message}"))
            };
        }
    }
}
