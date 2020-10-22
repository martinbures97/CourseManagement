using MediatR;

namespace CourseManagement.Application.Student.Commands.CreateStudent
{
    public sealed class CreateStudentCommand : IRequest<object>
    {
        public string Name { get; set; }
    }
}