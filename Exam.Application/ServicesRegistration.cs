using Exam.Application.Behaviors;
using Exam.Application.Repositories;
using Microsoft.Extensions.Configuration;
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
            });
            return services;
        }
    }
}
