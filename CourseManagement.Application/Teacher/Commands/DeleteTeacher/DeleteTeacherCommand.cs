using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Teacher.Commands.DeleteTeacher
{
    public sealed class DeleteTeacherCommand : IRequest, IIdRequest
    {
        public string Id { get; set; }
    }
}