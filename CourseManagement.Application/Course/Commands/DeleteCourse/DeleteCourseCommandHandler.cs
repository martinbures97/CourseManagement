using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Course.Commands.DeleteCourse
{
    public sealed class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseService _courseService;

        public DeleteCourseCommandHandler(
            IUnitOfWork unitOfWork,
            ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _courseService = courseService;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            await _courseService.DeleteCourseAsync(request.Id, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}