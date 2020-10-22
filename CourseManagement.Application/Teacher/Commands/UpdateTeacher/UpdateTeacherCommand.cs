using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Teacher.Commands.UpdateTeacher
{
    public sealed class UpdateTeacherCommand : IRequest, IIdRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}