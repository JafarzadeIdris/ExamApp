using Exam.MVC.Middlewares;
using Exam.MVC.Models;

namespace Exam.MVC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());
            services.AddExceptionHandler<CustomExceptionHandler>();
            return services;
        }
    }
}
