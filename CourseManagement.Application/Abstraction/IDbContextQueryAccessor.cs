using CourseManagement.Domain.Common.Interfaces;
using System.Linq;

namespace CourseManagement.Application.Abstraction
{
    public interface IDbContextQueryAccessor
    {
        IQueryable<TEntity> GetQueryable<TEntity>()
           where TEntity : class, IEntity;
    }
}