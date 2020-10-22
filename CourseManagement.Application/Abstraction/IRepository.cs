using CourseManagement.Domain.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Abstraction
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity> FindAsync(string id, IQueryable<TEntity> query, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true);

        IQueryable<TEntity> GetQueryable();
    }
}