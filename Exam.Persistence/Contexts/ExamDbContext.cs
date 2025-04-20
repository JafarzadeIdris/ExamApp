using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Persistence.Contexts
{
    public class ExamDbContext(DbContextOptions<ExamDbContext> options) : DbContext(options)
    {
        public DbSet<ExamEntity> Exams { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
