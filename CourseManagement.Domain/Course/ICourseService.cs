using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Domain
{
    public interface ICourseService
    {
        void CreateCourse(Course course);

        void UpdateCourse(Course course);

        Task DeleteCourseAsync(string id, CancellationToken cancellationToken);

        Task<Course> FindCourseAsync(string id, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true);
    }
}