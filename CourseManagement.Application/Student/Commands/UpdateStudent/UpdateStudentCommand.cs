using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Student.Commands.UpdateStudent
{
    public sealed class UpdateStudentCommand : IRequest, IIdRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}