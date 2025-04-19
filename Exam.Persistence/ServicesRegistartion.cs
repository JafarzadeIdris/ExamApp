using Exam.Application.Repositories;
using Exam.Persistence.Contexts;
using Exam.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Exam.Persistence
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


            services.AddDbContext<ExamDbContext>(options =>
                 options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")
                 ), ServiceLifetime.Transient);

            return services;
        }
    }
}
