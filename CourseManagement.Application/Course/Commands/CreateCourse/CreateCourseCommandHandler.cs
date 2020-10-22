using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Course.Commands.CreateCourse
{
    public sealed class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, object>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseFactory _courseFactory;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public CreateCourseCommandHandler(
            IUnitOfWork unitOfWork,
            ICourseFactory courseFactory,
            ICourseService courseService,
            ITeacherService teacherService,
            IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _courseFactory = courseFactory;
            _courseService = courseService;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public async Task<object> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.FindTeacherAsync(request.TeacherId, cancellationToken, false);
            if (teacher?.DeletedOn != null)
            {
                throw new Exceptions.ApplicationLayerException($"Cannot assign teacher {teacher} to course, because teacher is deleted.");
            }

            var course = _courseFactory.NewCourse(request.Name, request.MaxCapacity);

            course.SetCapacity(request.MaxCapacity);
            course.SetDescription(request.Description);
            course.SetName(request.Name);

            if (teacher != null)
            {
                course.SetTeacher(teacher);
            }

            if (request.StudentIds.Any())
            {
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
                        throw new Exceptions.ApplicationLayerException($"Cannot assign student {student} to course, because student is deleted.");
                    }
                    course.AddStudent(student);
                }
            }

            _courseService.CreateCourse(course);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new
            {
                CourseId = course.Id
            };
        }
    }
}