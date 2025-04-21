using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Text.Json;

namespace Exam.MVC.Middlewares
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            
            _logger.LogError(exception, "Unhandled exception occurred at {Path}", httpContext.Request.Path);

            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            string title = string.Empty;

            switch (exception)
            {
                case ArgumentNullException:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    title = "Required argument was null";
                    break;

                case ValidationException:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    title = "Invalid input data";
                    break;

                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    title = "An unexpected error occurred";
                    break;
            }

            var response = new
            {
                title = title,
                status = httpContext.Response.StatusCode,
                detail = exception.Message,
                traceId = httpContext.TraceIdentifier
            };

            var json = JsonSerializer.Serialize(response);
            await httpContext.Response.WriteAsync(json, cancellationToken);

            return true;
        }
    }
}
