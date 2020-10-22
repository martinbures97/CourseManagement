using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Teacher.Queries.GetTeacher
{
    public sealed class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, TeacherDto>
    {
        private readonly ITeacherService _teacherService;
        private readonly IEntityToDtoMapper<Domain.Teacher> _teacherMapper;

        public GetTeacherQueryHandler(
            ITeacherService teacherService,
            IEntityToDtoMapper<Domain.Teacher> teacherMapper)
        {
            _teacherService = teacherService;
            _teacherMapper = teacherMapper;
        }

        public async Task<TeacherDto> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.FindTeacherAsync(request.Id, cancellationToken);
            return _teacherMapper.MapToDto<TeacherDto>(teacher);
        }
    }
}