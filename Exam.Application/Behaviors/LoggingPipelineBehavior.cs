using MediatR;
using System.Diagnostics;
using Microsoft.Extensions.Logging;


namespace Exam.Application.Behaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull, IRequest<TResponse>
     where TResponse : notnull
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling process started for {request}");
            var metric = Stopwatch.StartNew();
            var response = await next();
            metric.Stop();

            if (metric.Elapsed.Seconds > 5)
                _logger.LogWarning($"Handling process took too much time. Maybe it needs to be refactored: {metric.Elapsed}");

            _logger.LogInformation($"Handling process done for {request} and you have response {response}");
            return response;
        }
    }
}
