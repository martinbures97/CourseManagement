using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Student.Commands.DeleteStudent
{
    public sealed class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentService _studentService;

        public DeleteStudentCommandHandler(
            IUnitOfWork unitOfWork,
            IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _studentService = studentService;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentService.DeleteStudentAsync(request.Id, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}