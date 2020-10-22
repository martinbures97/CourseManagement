using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Student.Commands.DeleteStudent
{
    public sealed class DeleteStudentCommand : IRequest, IIdRequest
    {
        public string Id { get; set; }
    }
}