using CourseManagement.Application.Abstraction;
using CourseManagement.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.EntityFramework
{
    internal class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly CourseManagementDbContext _courseManagementDbContext;

        public EntityFrameworkUnitOfWork(
            CourseManagementDbContext courseManagementDbContext)
        {
            _courseManagementDbContext = courseManagementDbContext;
        }

        public void Commit()
        {
            _courseManagementDbContext.SaveChanges();
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _courseManagementDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}