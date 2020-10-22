using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using CourseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Services
{
    internal sealed class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(
            IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void CreateTeacher(Teacher teacher)
        {
            _teacherRepository.Create(teacher);
        }

        public async Task DeleteTeacherAsync(string id, CancellationToken cancellationToken)
        {
            var teacher = await FindTeacherAsync(id, cancellationToken);

            if (teacher.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Teacher {teacher} is already deleted. Can't process delete.");
            }

            if (teacher.Courses.Any())
            {
                throw new ApplicationLayerException($"Teacher {teacher} cannot be deleted because he is still assigned to some course/s.");
            }

            _teacherRepository.Delete(teacher);
        }

        public async Task<Teacher> FindTeacherAsync(string id, CancellationToken cancellationToken, bool throwExceptionWhenNotFound = true)
        {
            var query = _teacherRepository
                 .GetQueryable()
                 .Include(x => x.Courses)
                     .ThenInclude(x => x.CourseStudents)
                        .ThenInclude(x => x.Course)
                     .ThenInclude(x => x.CourseStudents)
                        .ThenInclude(x => x.Student);


            return await _teacherRepository.FindAsync(id, query, cancellationToken, throwExceptionWhenNotFound);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            if (teacher.DeletedOn != null)
            {
                throw new ApplicationLayerException($"Teacher {teacher} is already deleted. Can't process delete.");
            }

            _teacherRepository.Update(teacher);
        }
    }
}