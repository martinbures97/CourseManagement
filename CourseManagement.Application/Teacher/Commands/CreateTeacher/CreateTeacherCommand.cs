using MediatR;

namespace CourseManagement.Application.Teacher.Commands.CreateTeacher
{
    public sealed class CreateTeacherCommand : IRequest<object>
    {
        public string Name { get; set; }
    }
}