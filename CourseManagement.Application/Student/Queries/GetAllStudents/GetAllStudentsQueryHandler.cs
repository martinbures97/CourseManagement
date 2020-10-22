using CourseManagement.Application.Abstraction;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Student.Queries.GetAllStudents
{
    public sealed class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IToListAsyncWrapper _toListAsyncWrapper;
        private readonly IEntityToDtoMapper<Domain.Student> _studentMapper;
        private readonly IDbContextQueryAccessor _dbContextQueryAccessor;

        public GetAllStudentsQueryHandler(
            IToListAsyncWrapper toListAsyncWrapper,
            IEntityToDtoMapper<Domain.Student> studentMapper,
            IDbContextQueryAccessor dbContextQueryAccessor)
        {
            _toListAsyncWrapper = toListAsyncWrapper;
            _studentMapper = studentMapper;
            _dbContextQueryAccessor = dbContextQueryAccessor;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContextQueryAccessor
                            .GetQueryable<Domain.Student>()
                                .Where(x => x.DeletedOn == null);

            var projectedQuery = _studentMapper
                .ProjectTo<StudentDto>(query);

            return await _toListAsyncWrapper
                .ToListAsync(projectedQuery, cancellationToken);
        }
    }
}