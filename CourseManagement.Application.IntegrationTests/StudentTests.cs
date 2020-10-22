using CourseManagement.Application.Student.Commands.CreateStudent;
using CourseManagement.Application.Student.Commands.DeleteStudent;
using CourseManagement.Application.Student.Commands.UpdateStudent;
using CourseManagement.Application.Student.Queries.GetAllStudents;
using CourseManagement.Application.Student.Queries.GetStudent;
using System.Threading.Tasks;
using Xunit;

namespace CourseManagement.Application.IntegrationTests
{
    public class StudentTests : TestBase
    {
        public StudentTests()
        {
            RunBeforeAnyTest();
        }

        [Fact]
        public async Task TestCreateStudentCommand()
        {
            var request = new CreateStudentCommand();
            request.Name = "Test";

            var result = await mediator.Send(request);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestUpdateStudentCommand()
        {
            var student = CreateTestStudent();

            var request = new UpdateStudentCommand();
            request.Id = student.Id;
            request.Name = "Test2";

            await mediator.Send(request);

            student = await StudentService.FindStudentAsync(student.Id, default);
            Assert.Equal("Test2", student.Name);
        }

        [Fact]
        public async Task TestDeleteStudentCommand()
        {
            var student = CreateTestStudent();

            var deleteRequest = new DeleteStudentCommand();
            deleteRequest.Id = student.Id;
            await mediator.Send(deleteRequest);
        }

        [Fact]
        public async Task TestGetStudentQuery()
        {
            var student = CreateTestStudent();

            var request = new GetStudentQuery();
            request.Id = student.Id;
            var result = await mediator.Send(request);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGetAllStudentsQuery()
        {
            CreateTestStudent();

            var request = new GetAllStudentsQuery();
            var result = await mediator.Send(request);
            Assert.Single(result);
        }

        private Domain.Student CreateTestStudent()
        {
            var student = StudentFactory.NewStudent("Test");
            StudentService.CreateStudent(student);
            UnitOfWork.Commit();
            return student;
        }
    }
}
