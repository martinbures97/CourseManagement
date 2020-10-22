using CourseManagement.Application.Abstraction;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Teacher.Queries.GetAllTeachers
{
    public sealed class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<TeacherDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IToListAsyncWrapper _toListAsyncWrapper;
        private readonly IDbContextQueryAccessor _dbContextQueryAccessor;
        private readonly IEntityToDtoMapper<Domain.Teacher> _teacherMapper;

        public GetAllTeachersQueryHandler(
            IIdentityService identityService,
            IToListAsyncWrapper toListAsyncWrapper,
            IDbContextQueryAccessor dbContextQueryAccessor,
            IEntityToDtoMapper<Domain.Teacher> teacherMapper)
        {
            _identityService = identityService;
            _toListAsyncWrapper = toListAsyncWrapper;
            _dbContextQueryAccessor = dbContextQueryAccessor;
            _teacherMapper = teacherMapper;
        }

        public async Task<IEnumerable<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _toListAsyncWrapper.ToListAsync(
                    _teacherMapper
                        .ProjectTo<TeacherDto>(
                            _dbContextQueryAccessor.GetQueryable<Domain.Teacher>()
                                .Where(x => x.DeletedOn == null)), cancellationToken);
        }
    }
}