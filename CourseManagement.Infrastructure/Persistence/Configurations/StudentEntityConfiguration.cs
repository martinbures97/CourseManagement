using CourseManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Infrastructure.Persistence.Configurations
{
    internal class StudentEntityConfiguration : EntityTypeConfigurationBase<Student>
    {
        public StudentEntityConfiguration() : base("Students")
        {
        }

        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Name)
               .HasMaxLength(50);

            builder.HasMany(x => x.CourseStudents)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            base.Configure(builder);
        }
    }
}