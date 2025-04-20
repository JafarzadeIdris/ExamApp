using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exam.Domain.Entities;

namespace Exam.Persistence.EntityConfigration
{
    public class ExamConfigration : IEntityTypeConfiguration<ExamEntity>
    {
        public void Configure(EntityTypeBuilder<ExamEntity> builder)
        {
            builder.HasKey(e => e.Id);


            builder.Property(e => e.ExamDate)
                  .HasColumnType("date")
            .IsRequired();

            builder.Property(e => e.Score)
                  .HasColumnType("int")
                  .IsRequired();


            builder.HasOne(e => e.Lesson)
                  .WithMany(s => s.Exams)
                  .HasForeignKey(e => e.LessonId);

            builder.HasOne(e => e.Student)
                  .WithMany(s => s.Exams)
                  .HasForeignKey(e => e.StudentId);
        }
    }
}
