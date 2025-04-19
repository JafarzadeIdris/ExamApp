using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Exam.Persistence.EntityConfigration
{
    internal class StudentConfigration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.Number)
            .IsRequired();

            builder.Property(st => st.Name)
                  .HasMaxLength(30)
            .IsRequired();

            builder.Property(st => st.Surname)
                  .HasMaxLength(30)
            .IsRequired();

            builder.Property(st => st.ClassLevel)
                  .IsRequired();

            builder.HasMany(st => st.Exams)
                  .WithOne(e => e.Student)
                  .HasForeignKey(e => e.Id)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
