using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Infrastructure.Identity
{
    public sealed class CourseManagementIdentityDbContext : IdentityDbContext
    {
        public CourseManagementIdentityDbContext(
            DbContextOptions<CourseManagementIdentityDbContext> options) : base(options)
        {
        }
    }
}