using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.EntityFramework
{
    public class FakeRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        readonly List<TEntity> _fakeDb;

        public FakeRepository()
        {
            _fakeDb = new List<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _fakeDb.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _fakeDb.Remove(entity);
        }

        public async Task<TEntity> FindAsync(string id, IQueryable<TEntity> query, CancellationToken cancellationToken, bool throwExeptionWhenNotFound = true)
        {
            var result = _fakeDb.Find(x => x.Id == id);

            if (throwExeptionWhenNotFound && result is null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            return result;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _fakeDb.AsQueryable();
        }

        public void Update(TEntity entity)
        {
            var existingEntity = _fakeDb.Find(x => x.Id == entity.Id);
            existingEntity = entity;
        }
    }
}
