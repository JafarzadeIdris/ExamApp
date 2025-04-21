using Exam.Domain.Entities;
using Exam.Persistence.Contexts;
using Microsoft.Extensions.Logging;


namespace Exam.Persistence.Seed
{
    public class DatabaseInitializer
    {
        public static async Task SeedAsync(ExamDbContext context, ILogger logger)
        {
            if (!context.Students.Any())
            {
                var teacher1 = new TeacherEntity("Idris", "Cafarzade") { Id=Guid.NewGuid()};
                var teacher2 = new TeacherEntity("Aysel", "Aliyeva") { Id = Guid.NewGuid() };

                var lesson1 = new LessonEntity("Math", "M01", 10, teacher1.Id) { Id = Guid.NewGuid() };
                var lesson2 = new LessonEntity("Physics", "P02", 11, teacher2.Id) { Id = Guid.NewGuid() };

                var student1 = new StudentEntity(1001, "Tural", "Hasanov", 10) { Id = Guid.NewGuid() };
                var student2 = new StudentEntity(1002, "Nigar", "Mammadova", 11) { Id = Guid.NewGuid() };

                var exam1 = new ExamEntity(DateTime.UtcNow.AddDays(1), 85, lesson1.Id, student1.Id) { Id = Guid.NewGuid() };
                var exam2 = new ExamEntity(DateTime.UtcNow.AddDays(1), 90, lesson2.Id, student2.Id) { Id = Guid.NewGuid() };

                await context.Teachers.AddRangeAsync(teacher1, teacher2);
                await context.Lessons.AddRangeAsync(lesson1, lesson2);
                await context.Students.AddRangeAsync(student1, student2);

                await context.SaveChangesAsync();

                await context.Exams.AddRangeAsync(exam1, exam2);
                await context.SaveChangesAsync();

                logger.LogInformation("✅ Seed data successfully inserted.");
            }
        }
    }
}
