using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Teacher.Commands.DeleteTeacher
{
    public sealed class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeacherService _teacherService;

        public DeleteTeacherCommandHandler(
            IUnitOfWork unitOfWork,
            ITeacherService teacherService)
        {
            _unitOfWork = unitOfWork;
            _teacherService = teacherService;
        }

        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            await _teacherService.DeleteTeacherAsync(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}