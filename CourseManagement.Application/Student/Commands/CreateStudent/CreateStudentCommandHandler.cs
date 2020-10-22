using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Student.Commands.CreateStudent
{
    public sealed class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, object>
    {
        private readonly IStudentFactory _studentFactory;
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommandHandler(
            IStudentFactory studentFactory,
            IStudentService studentService,
            IUnitOfWork unitOfWork)
        {
            _studentFactory = studentFactory;
            _studentService = studentService;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _studentFactory.NewStudent(request.Name);

            _studentService.CreateStudent(student);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new
            {
                StudentId = student.Id
            };
        }
    }
}