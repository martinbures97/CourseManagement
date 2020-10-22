using CourseManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Infrastructure.Persistence.Configurations
{
    internal class TeacherEntityConfiguration : EntityTypeConfigurationBase<Teacher>
    {
        public TeacherEntityConfiguration() : base("Teachers")
        {
        }

        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);

            base.Configure(builder);
        }
    }
}