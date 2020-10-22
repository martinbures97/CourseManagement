using Xunit;

namespace CourseManagement.Domain.UnitTests
{
    public class TeacherTests : TestBase
    {
        ITeacherFactory _teacherFactory;

        public TeacherTests()
        {
            base.RunBeforeAnyTest();
            _teacherFactory = (ITeacherFactory)ServiceProvider.GetService(typeof(ITeacherFactory));
        }

        [Fact]
        public void TestFactory()
        {
            var teacher = _teacherFactory.NewTeacher("Test");
            Assert.Equal("Test", teacher.Name);
        }

        [Fact]
        public void TestSetName()
        {
            var teacher = _teacherFactory.NewTeacher("Test");
            teacher.SetName("Test2");
            Assert.Equal("Test2", teacher.Name);
        }
    }
}
