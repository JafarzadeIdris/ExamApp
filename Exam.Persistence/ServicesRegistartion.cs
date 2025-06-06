﻿using Exam.Application;
using Exam.Application.Abstractions.Repository;
using Exam.Persistence.Contexts;
using Exam.Persistence.Repositories;
using Exam.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Exam.Persistence
{
    public static class ServicesRegistration
    {
        public static void ApplyMigrations(this IHost app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ExamDbContext>();
                context.Database.Migrate();

                var logger = services.GetRequiredService<ILogger<ExamDbContext>>();
                logger.LogInformation("✅ Database migrations applied successfully.");

                
                DatabaseInitializer.SeedAsync(context, logger).GetAwaiter().GetResult();

            }
            catch (Exception exception)
            {
                var logger = services.GetRequiredService<ILogger<ExamDbContext>>();
                logger.LogError(exception, "❌ An error occurred while applying migrations.");
                throw new Exception(exception.Message);
            }
        }
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExamRepository, ExamRepository>();

            services.AddDbContext<ExamDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddApplicationLayer();
            return services;
        }
    }
}
