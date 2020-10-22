using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Teacher.Commands.CreateTeacher
{
    public sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, object>
    {
        private readonly ILogger<CreateTeacherCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeacherFactory _teacherFactory;
        private readonly ITeacherService _teacherService;

        public CreateTeacherCommandHandler(
            ILogger<CreateTeacherCommandHandler> logger,
            IUnitOfWork unitOfWork,
            ITeacherFactory teacherFactory,
            ITeacherService teacherService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _teacherFactory = teacherFactory;
            _teacherService = teacherService;
        }

        public async Task<object> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = _teacherFactory.NewTeacher(request.Name);
            _teacherService.CreateTeacher(teacher);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new
            {
                TeacherId = teacher.Id
            };
        }
    }
}