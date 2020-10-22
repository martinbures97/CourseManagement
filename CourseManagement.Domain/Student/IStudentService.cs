using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Domain
{
    public interface IStudentService
    {
        void CreateStudent(Student student);

        void UpdateStudent(Student student);

        Task DeleteStudentAsync(string id, CancellationToken cancellationToken);

        Task<Student> FindStudentAsync(string id, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true);
    }
}