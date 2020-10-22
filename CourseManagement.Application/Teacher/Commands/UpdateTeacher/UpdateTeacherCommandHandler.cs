using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Teacher.Commands.UpdateTeacher
{
    public sealed class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeacherService _teacherService;

        public UpdateTeacherCommandHandler(
            IUnitOfWork unitOfWork,
            ITeacherService teacherService)
        {
            _unitOfWork = unitOfWork;
            _teacherService = teacherService;
        }

        public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.FindTeacherAsync(request.Id, cancellationToken);

            if (teacher.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Teacher {teacher} is already deleted. Can't process delete.");
            }

            teacher.SetName(request.Name);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}