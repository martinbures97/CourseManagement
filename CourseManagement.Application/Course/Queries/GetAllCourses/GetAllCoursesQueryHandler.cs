using CourseManagement.Application.Abstraction;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Course.Queries.GetAllCourses
{
    public sealed class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly IDbContextQueryAccessor _dbContextQueryAccessor;
        private readonly IToListAsyncWrapper _toListAsyncWrapper;
        private readonly IEntityToDtoMapper<Domain.Course> _courseMapper;

        public GetAllCoursesQueryHandler(
            IDbContextQueryAccessor dbContextQueryAccessor,
            IToListAsyncWrapper toListAsyncWrapper,
            IEntityToDtoMapper<Domain.Course> courseMapper)
        {
            _dbContextQueryAccessor = dbContextQueryAccessor;
            _toListAsyncWrapper = toListAsyncWrapper;
            _courseMapper = courseMapper;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _toListAsyncWrapper.ToListAsync(
                _courseMapper
                    .ProjectTo<CourseDto>(
                        _dbContextQueryAccessor
                            .GetQueryable<Domain.Course>()
                                .Where(x => x.DeletedOn == null)), cancellationToken);
        }
    }
}