using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Student.Queries.GetStudent
{
    public sealed class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {
        private readonly IStudentService _studentService;
        private readonly IEntityToDtoMapper<Domain.Student> _studentMapper;

        public GetStudentQueryHandler(
            IStudentService studentService,
            IEntityToDtoMapper<Domain.Student> studentMapper)
        {
            _studentService = studentService;
            _studentMapper = studentMapper;
        }

        public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.FindStudentAsync(request.Id, cancellationToken);
            return _studentMapper.MapToDto<StudentDto>(student);
        }
    }
}