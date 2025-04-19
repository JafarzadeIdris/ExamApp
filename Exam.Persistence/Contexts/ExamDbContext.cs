using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Persistence.Contexts
{
    public class ExamDbContext(DbContextOptions<ExamDbContext> options) : DbContext(options)
    {
        public DbSet<ExamEntity> ExamEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
