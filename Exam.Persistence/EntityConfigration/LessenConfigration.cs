using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Persistence.EntityConfigration
{
    public class LessenConfigration: IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Code)
                  .HasColumnType("char(3)")
            .IsRequired();

            builder.Property(s => s.Name)
                  .HasMaxLength(30)
            .IsRequired();

            builder.Property(s => s.ClassLevel)
            .IsRequired();

            builder.Property(s => s.TeacherId)
                  .IsRequired();

            builder.HasOne(s => s.Teacher)
                  .WithMany(t => t.Lessons)
                  .HasForeignKey(s => s.TeacherId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Exams)
                  .WithOne(e => e.Lesson)
                  .HasForeignKey(e => e.Id)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
