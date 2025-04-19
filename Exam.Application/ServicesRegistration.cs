using Exam.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Exam.Application.MapperProfiles;
namespace Exam.Application
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {

            services.AddAutoMapper(cfg => { cfg.AddProfile<MapperProfile>(); });
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ServicesRegistration).Assembly);
                config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
            });
            //services.AddAutoMapper(typeof(MapperProfile).Assembly);
            return services;
        }
    }
}
