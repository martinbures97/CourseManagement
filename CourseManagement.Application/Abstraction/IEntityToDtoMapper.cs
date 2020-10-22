using CourseManagement.Domain.Common.Interfaces;
using System.Linq;

namespace CourseManagement.Application.Abstraction
{
    public interface IEntityToDtoMapper<TEntity>
        where TEntity : IEntity
    {
        IQueryable<TResult> ProjectTo<TResult>(IQueryable<TEntity> query);
        TResult MapToDto<TResult>(TEntity entity);
    }
}