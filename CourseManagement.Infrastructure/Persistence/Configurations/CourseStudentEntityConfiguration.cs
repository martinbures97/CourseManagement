using CourseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Infrastructure.Persistence.Configurations
{
    internal class CourseStudentEntityConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.ToTable("CourseStudents");

            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseStudents)
                .HasForeignKey(x => x.CourseId);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.CourseStudents)
                .HasForeignKey(x => x.StudentId);
        }
    }
}