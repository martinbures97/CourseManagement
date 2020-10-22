using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Student.Queries.GetStudent
{
    public sealed class GetStudentQuery : IRequest<StudentDto>, IIdRequest
    {
        public string Id { get; set; }
    }
}