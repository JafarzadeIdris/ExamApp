using Exam.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Application
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ServicesRegistration).Assembly);
                config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
            });
            return services;
        }
    }
}
