using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(
            IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.Create(student);
        }

        public async Task DeleteStudentAsync(string id, CancellationToken cancellationToken)
        {
            var student = await FindStudentAsync(id, cancellationToken);

            if (student.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Student {student} is already deleted. Can't process delete.");
            }

            if (student.CourseStudents.Any())
            {
                throw new ApplicationLayerException($"Student {student} cannot be deleted because he is still assigned to some course/s.");
            }

            _studentRepository.Delete(student);
        }

        public async Task<Student> FindStudentAsync(string id, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true)
        {
            var query = _studentRepository
                .GetQueryable()
                .Include(x => x.CourseStudents)
                    .ThenInclude(x => x.Student)
                .Include(x => x.CourseStudents)
                    .ThenInclude(x => x.Course);

            return await _studentRepository.FindAsync(id, query, cancellationToken, throwExceptionWhenNotFound);
        }

        public void UpdateStudent(Student student)
        {
            if (student.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Student {student} is already deleted. Can't process delete.");
            }

            _studentRepository.Update(student);
        }
    }
}