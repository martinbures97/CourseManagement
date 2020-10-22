using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(
            IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void CreateCourse(Course course)
        {
            _courseRepository.Create(course);
        }

        public async Task DeleteCourseAsync(string id, CancellationToken cancellationToken)
        {
            var course = await FindCourseAsync(id, cancellationToken);

            if (course.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Course {course} is already deleted. Can't process delete.");
            }

            if (course.CourseStudents.Any())
            {
                throw new ApplicationLayerException($"The course {course} cannot be deleted if students are still assigned to it.");
            }

            _courseRepository.Delete(course);
        }

        public async Task<Course> FindCourseAsync(string id, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true)
        {
            var query = _courseRepository
                .GetQueryable()
                .Include(x => x.CourseStudents)
                    .ThenInclude(x => x.Student)
                .Include(x => x.CourseStudents)
                    .ThenInclude(x => x.Course);

            return await _courseRepository.FindAsync(id, query, cancellationToken, throwExceptionWhenNotFound);
        }

        public void UpdateCourse(Course course)
        {
            if (course.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Course {course} is already deleted. Can't process delete.");
            }

            _courseRepository.Update(course);
        }
    }
}