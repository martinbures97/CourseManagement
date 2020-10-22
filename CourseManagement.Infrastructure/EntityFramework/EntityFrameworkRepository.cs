using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain.Common;
using CourseManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.EntityFramework
{
    internal sealed class EntityFrameworkRepository<TEntity>
        : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly CourseManagementDbContext _courseManagementDbContext;

        public EntityFrameworkRepository(
            CourseManagementDbContext courseManagementDbContext)
        {
            _courseManagementDbContext = courseManagementDbContext;
        }

        public void Create(TEntity entity)
        {
            _courseManagementDbContext
                .Set<TEntity>()
                .Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _courseManagementDbContext.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _courseManagementDbContext
                .Set<TEntity>()
                .AsQueryable();
        }

        public async Task<TEntity> FindAsync(string id, IQueryable<TEntity> query, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true)
        {
            var entity = await query
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            if (throwExceptionWhenNotFound && entity is null)
                throw new NotFoundException(typeof(TEntity).Name, id);

            return entity;
        }

        public void Update(TEntity entity)
        {
            _courseManagementDbContext
                .Set<TEntity>()
                .Update(entity);
        }
    }
}