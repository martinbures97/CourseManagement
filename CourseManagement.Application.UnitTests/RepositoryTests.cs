using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using CouseManagement.Application.UnitTests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CourseManagement.Application.UnitTests
{
    public class RepositoryTest : TestBase
    {
        IRepository<Domain.Teacher> _repository;
        ITeacherFactory _teacherFactory;

        public RepositoryTest()
        {
            RunBeforeAnyTest();
            _repository = (IRepository<Domain.Teacher>)ServiceProvider.GetService(typeof(IRepository<Domain.Teacher>));
            _teacherFactory = (ITeacherFactory)ServiceProvider.GetService(typeof(ITeacherFactory));
        }

        [Fact]
        public void TestCreate()
        {
            var teacher = _teacherFactory.NewTeacher("Teacher");
            _repository.Create(teacher);
        }

        [Fact]
        public void TestUpdate()
        {
            var teacher = _teacherFactory.NewTeacher("Teacher");
            _repository.Create(teacher);

            teacher.SetName("Teacher2");

            _repository.Update(teacher);
        }

        [Fact]
        public void TestDelete()
        {
            var teacher = _teacherFactory.NewTeacher("Teacher");
            _repository.Create(teacher);

            _repository.Delete(teacher);
        }

        [Fact]
        public async Task TestFindAsync()
        {
            var teacher = _teacherFactory.NewTeacher("Teacher");
            _repository.Create(teacher);

            var foundTeacher = await _repository.FindAsync(null, new List<Domain.Teacher>().AsQueryable(), default);

            Assert.NotNull(foundTeacher);
        }
    }
}
