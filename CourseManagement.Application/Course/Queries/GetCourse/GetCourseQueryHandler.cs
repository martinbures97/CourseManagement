using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Course.Queries.GetCourse
{
    public sealed class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseDto>
    {
        private readonly ICourseService _courseService;
        private readonly IEntityToDtoMapper<Domain.Course> _courseMapper;

        public GetCourseQueryHandler(
            ICourseService courseService,
            IEntityToDtoMapper<Domain.Course> courseMapper)
        {
            _courseService = courseService;
            _courseMapper = courseMapper;
        }

        public async Task<CourseDto> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseService.FindCourseAsync(request.Id, cancellationToken);
            return _courseMapper.MapToDto<CourseDto>(course);
        }
    }
}