using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Student.Commands.UpdateStudent
{
    public sealed class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentService _studentService;

        public UpdateStudentCommandHandler(
            IUnitOfWork unitOfWork,
            IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _studentService = studentService;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.FindStudentAsync(request.Id, cancellationToken);

            if (student.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Student {student} is already deleted. Can't process delete.");
            }

            student.SetName(request.Name);

            _studentService.UpdateStudent(student);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}