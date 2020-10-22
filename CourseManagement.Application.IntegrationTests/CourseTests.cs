using CourseManagement.Application.Course.Commands.CreateCourse;
using CourseManagement.Application.Course.Commands.DeleteCourse;
using CourseManagement.Application.Course.Commands.UpdateCourse;
using CourseManagement.Application.Course.Queries.GetAllCourses;
using CourseManagement.Application.Course.Queries.GetCourse;
using System.Threading.Tasks;
using Xunit;

namespace CourseManagement.Application.IntegrationTests
{
    public class CourseTests : TestBase
    {
        public CourseTests()
        {
            RunBeforeAnyTest();
        }

        [Fact]
        public async Task TestCreateCourseCommand()
        {
            var student = StudentFactory.NewStudent("test");
            StudentService.CreateStudent(student);

            UnitOfWork.Commit();

            var request = new CreateCourseCommand();
            request.Name = "Test";
            request.Description = "Test";
            request.MaxCapacity = 1;
            request.StudentIds = new string[]
            {
                student.Id,
            };

            var result = await mediator.Send(request);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestUpdateCourseCommand()
        {
            var course = CreateTestCourse();

            var student = StudentFactory.NewStudent("test");
            StudentService.CreateStudent(student);

            UnitOfWork.Commit();


            var request = new UpdateCourseCommand();
            request.Id = course.Id;
            request.Name = "Test2";
            request.Description = "Test";
            request.MaxCapacity = 1;
            request.StudentIds = new string[]
            {
                student.Id,
            };

            await mediator.Send(request);

            course = await CourseService.FindCourseAsync(course.Id, default);
            Assert.Equal("Test2", course.Name);
        }

        [Fact]
        public async Task TestDeleteCourseCommand()
        {
            var course = CreateTestCourse();

            var deleteRequest = new DeleteCourseCommand();
            deleteRequest.Id = course.Id;
            await mediator.Send(deleteRequest);
        }

        [Fact]
        public async Task TestGetCourseQuery()
        {
            var course = CreateTestCourse();

            var request = new GetCourseQuery();
            request.Id = course.Id;
            var result = await mediator.Send(request);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGetAllCoursesQuery()
        {
            CreateTestCourse();

            var request = new GetAllCoursesQuery();
            var result = await mediator.Send(request);
            Assert.Single(result);
        }

        private Domain.Course CreateTestCourse()
        {
            var course = CourseFactory.NewCourse("Test", 3);
            CourseService.CreateCourse(course);
            UnitOfWork.Commit();
            return course;
        }
    }
}
