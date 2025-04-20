using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using static CSharpFunctionalExtensions.Result;



namespace Exam.Application.Behaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull, IRequest<TResponse>
     where TResponse : notnull
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;
        private readonly IConfiguration _configuration;
        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger, IConfiguration configuration)
        {
            _logger = logger ;
            _configuration = configuration;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling process started for {request}");
            var stopwatch = Stopwatch.StartNew();
            var response = await next(cancellationToken);
            stopwatch.Stop();

            var elapsedTime = stopwatch.Elapsed.TotalSeconds;
            _logger.LogInformation(
                "Handling process for {Request} completed in {ElapsedTime}s. Response: {Response}",
                request,
                elapsedTime,
                response
            );
            return response;
        }
    }
}
