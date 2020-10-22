using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Course.Commands.UpdateCourse
{
    public sealed class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public UpdateCourseCommandHandler(
            IUnitOfWork unitOfWork,
            ICourseService courseService,
            ITeacherService teacherService,
            IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _courseService = courseService;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseService.FindCourseAsync(request.Id, cancellationToken);

            if (course.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Course {course} is already deleted. Can't process delete.");
            }

            course.SetCapacity(request.MaxCapacity);
            course.SetDescription(request.Description);
            course.SetName(request.Name);

            if (string.IsNullOrWhiteSpace(request.TeacherId))
            {
                if (course.Teacher != null)
                {
                    course.DeleteTeacher(course.Teacher);
                }
            }
            else
            {
                var teacher = await _teacherService.FindTeacherAsync(request.TeacherId, cancellationToken);
                if (teacher.DeletedOn != null)
                {
                    throw new ApplicationLayerException($"Cannot assign teacher {teacher} to course {course}, because teacher is deleted.");
                }
                course.SetTeacher(teacher);
            }

            var studentIdsForDelete = course.CourseStudents.Where(x => !request.StudentIds.Contains(x.StudentId)).Select(x => x.StudentId).ToList();
            var studentIdsForAdd = request.StudentIds.Where(x => !course.CourseStudents.Select(x => x.StudentId).Contains(x)).ToList();

            foreach (var studentId in studentIdsForDelete)
            {
                var student = await _studentService.FindStudentAsync(studentId, cancellationToken);
                course.DeleteStudent(student);
            }

            foreach (var studentId in studentIdsForAdd)
            {
                var student = await _studentService.FindStudentAsync(studentId, cancellationToken);
                if (student.DeletedOn != null)
                {
                    throw new ApplicationLayerException($"Cannot assign student {student} to course {course}, because student is deleted.");
                }
                course.AddStudent(student);
            }

            _courseService.UpdateCourse(course);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}