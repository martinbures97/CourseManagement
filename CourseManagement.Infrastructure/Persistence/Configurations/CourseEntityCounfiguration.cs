using CourseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Infrastructure.Persistence.Configurations
{
    internal class CourseEntityCounfiguration : EntityTypeConfigurationBase<Course>
    {
        public CourseEntityCounfiguration() : base("Courses")
        {
        }

        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name)
               .HasMaxLength(50);

            builder.Property(x => x.Description)
               .HasMaxLength(250);

            builder.Metadata
                .FindNavigation(nameof(Course.CourseStudents))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.CourseStudents)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            builder
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.TeacherId);

            base.Configure(builder);
        }
    }
}