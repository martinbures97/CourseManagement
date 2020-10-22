using CourseManagement.Application.Teacher.Commands.CreateTeacher;
using CourseManagement.Application.Teacher.Commands.DeleteTeacher;
using CourseManagement.Application.Teacher.Commands.UpdateTeacher;
using CourseManagement.Application.Teacher.Queries.GetAllTeachers;
using CourseManagement.Application.Teacher.Queries.GetTeacher;
using System.Threading.Tasks;
using Xunit;

namespace CourseManagement.Application.IntegrationTests
{
    public class TeacherTests : TestBase
    {
        public TeacherTests()
        {
            RunBeforeAnyTest();
        }

        [Fact]
        public async Task TestCreateTeacherCommand()
        {
            var request = new CreateTeacherCommand();
            request.Name = "Test";

            var result = await mediator.Send(request);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestUpdateTeacherCommand()
        {
            var teacher = CreateTestTeacher();

            var request = new UpdateTeacherCommand();
            request.Id = teacher.Id;
            request.Name = "Test2";

            await mediator.Send(request);

            teacher = await TeacherService.FindTeacherAsync(teacher.Id, default);
            Assert.Equal("Test2", teacher.Name);
        }

        [Fact]
        public async Task TestDeleteTeacherCommand()
        {
            var teacher = CreateTestTeacher();

            var deleteRequest = new DeleteTeacherCommand();
            deleteRequest.Id = teacher.Id;
            await mediator.Send(deleteRequest);
        }

        [Fact]
        public async Task TestGetTeacherQuery()
        {
            var teacher = CreateTestTeacher();

            var request = new GetTeacherQuery();
            request.Id = teacher.Id;
            var result = await mediator.Send(request);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGetAllTeachersQuery()
        {
            CreateTestTeacher();

            var request = new GetAllTeachersQuery();
            var result = await mediator.Send(request);
            Assert.Single(result);
        }

        private Domain.Teacher CreateTestTeacher()
        {
            var teacher = TeacherFactory.NewTeacher("Test");
            TeacherService.CreateTeacher(teacher);
            UnitOfWork.Commit();
            return teacher;
        }
    }
}
