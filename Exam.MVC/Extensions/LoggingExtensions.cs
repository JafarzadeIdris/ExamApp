using Exam.Infrastructure.Loging;
using Serilog;

namespace Exam.MVC.Extensions
{
    public static class LoggingExtensions
    {
        public static void ConfigureSerilogLogging(this WebApplicationBuilder builder)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables();

            Log.Logger = SerilogConfiguration.ConfigureSerilog(builder.Configuration, env);
            builder.Host.UseSerilog();
        }
    }
}
