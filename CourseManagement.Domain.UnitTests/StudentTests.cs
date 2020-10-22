using Xunit;

namespace CourseManagement.Domain.UnitTests
{
    public class StudentTest : TestBase
    {
        IStudentFactory _studentFactory;

        public StudentTest()
        {
            base.RunBeforeAnyTest();
            _studentFactory = (IStudentFactory)ServiceProvider.GetService(typeof(IStudentFactory));
        }

        [Fact]
        public void TestFactory()
        {
            var student = _studentFactory.NewStudent("Test");
            Assert.Equal("Test", student.Name);
        }

        [Fact]
        public void TestSetName()
        {
            var student = _studentFactory.NewStudent("Test");
            student.SetName("Test2");
            Assert.Equal("Test2", student.Name);
        }
    }
}
