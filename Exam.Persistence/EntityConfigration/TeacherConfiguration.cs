using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Persistence.EntityConfigration
{
    public class TeacherConfiguration:IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FirstName)
                  .HasMaxLength(20)
                  .IsRequired();

            builder.Property(t => t.LastName)
                  .HasMaxLength(20)
                  .IsRequired();

            builder.HasMany(t => t.Lessons)
                  .WithOne(s => s.Teacher)
                  .HasForeignKey(s => s.TeacherId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
   
}
