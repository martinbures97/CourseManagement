using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Domain
{
    public interface ITeacherService
    {
        void CreateTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        Task DeleteTeacherAsync(string id, CancellationToken cancellationToken);

        Task<Teacher> FindTeacherAsync(string id, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true);
    }
}