using Exam.Application;
using Exam.Application.Abstractions.Repository;
using Exam.Persistence.Contexts;
using Exam.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Persistence
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<ExamDbContext>(options =>
                 options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")
                 ), ServiceLifetime.Scoped);
            services.AddApplicationLayer();
            return services;
        }
    }
}
