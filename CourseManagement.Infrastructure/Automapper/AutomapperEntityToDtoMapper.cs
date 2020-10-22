using AutoMapper;
using CourseManagement.Application.Abstraction;
using CourseManagement.Domain.Common;
using System.Linq;

namespace CourseManagement.Infrastructure.Automapper
{
    public sealed class AutomapperEntityToDtoMapper<TEntity> : IEntityToDtoMapper<TEntity>
        where TEntity : Entity
    {
        private readonly IMapper _mapper;

        public AutomapperEntityToDtoMapper(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        public TResult MapToDto<TResult>(TEntity entity)
        {
            return _mapper.Map<TResult>(entity);
        }

        public IQueryable<TResult> ProjectTo<TResult>(IQueryable<TEntity> query)
        {
            return _mapper.ProjectTo<TResult>(query);
        }
    }
}