using Xunit;

namespace CourseManagement.Domain.UnitTests
{
    public class CourseTests : TestBase
    {
        ICourseFactory _courseFactory;
        ITeacherFactory _teacherFactory;
        IStudentFactory _studentFactory;

        public CourseTests()
        {
            base.RunBeforeAnyTest();
            _courseFactory = (ICourseFactory)base.ServiceProvider.GetService(typeof(ICourseFactory));
            _teacherFactory = (ITeacherFactory)base.ServiceProvider.GetService(typeof(ITeacherFactory));
            _studentFactory = (IStudentFactory)base.ServiceProvider.GetService(typeof(IStudentFactory));
        }

        [Fact]
        public void TestFactory()
        {
            var course = GetTestingCourse();
            Assert.Equal("Test", course.Name);
            Assert.Equal(5, course.MaxCapacity);
        }

        [Fact]
        public void TestSetMaxCapacity()
        {
            var course = GetTestingCourse();
            course.SetCapacity(10);
            Assert.Equal(10, course.MaxCapacity);
        }

        [Fact]
        public void TestSetDescription()
        {
            var course = GetTestingCourse();
            course.SetDescription("Test");
            Assert.Equal("Test", course.Description);
        }

        [Fact]
        public void TestSetName()
        {
            var course = GetTestingCourse();
            course.SetName("Test2");
            Assert.Equal("Test2", course.Name);
        }

        [Fact]
        public void TestSetTeacher()
        {
            var course = GetTestingCourse();
            var teacher = _teacherFactory.NewTeacher("Teacher");
            course.SetTeacher(teacher);
            Assert.NotNull(course.Teacher);
        }

        [Fact]
        public void TestDeleteTeacher()
        {
            var course = GetTestingCourse();
            var teacher = _teacherFactory.NewTeacher("Teacher");
            course.SetTeacher(teacher);
            course.DeleteTeacher(teacher);
            Assert.Null(course.Teacher);
        }


        [Fact]
        public void TestAddStudent()
        {
            var course = GetTestingCourse();
            var student = _studentFactory.NewStudent("Student");

            course.AddStudent(student);

            Assert.Equal(1, course.CourseStudents.Count);
        }

        [Fact]
        public void TestDeleteStudent()
        {
            var course = GetTestingCourse();
            var student = _studentFactory.NewStudent("Student");

            course.AddStudent(student);

            course.DeleteStudent(student);

            Assert.Equal(0, course.CourseStudents.Count);
        }

        private Course GetTestingCourse()
        {
            return _courseFactory.NewCourse("Test", 5);
        }
    }
}
