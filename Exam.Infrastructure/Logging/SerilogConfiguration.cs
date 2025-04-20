using System.Reflection;
using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Elasticsearch;

namespace Exam.Infrastructure.Loging
{
    public static class SerilogConfiguration
    {
        public static ILogger ConfigureSerilog(IConfiguration configuration, string environment)
        {
            var elasticUri = configuration["ElasticConfiguration:Uri"]
                         ?? throw new ArgumentNullException("ElasticConfiguration:Uri");

            var indexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}";

            var elasticOptions = new ElasticsearchSinkOptions(new Uri(elasticUri))
            {
                AutoRegisterTemplate = true,
                NumberOfReplicas = 1,
                NumberOfShards = 2,
                IndexFormat = indexFormat
            };

            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Environment", environment)
                .WriteTo.Console()
                .WriteTo.Elasticsearch(elasticOptions)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
