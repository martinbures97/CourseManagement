using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Teacher.Queries.GetTeacher
{
    public class GetTeacherQuery : IRequest<TeacherDto>, IIdRequest
    {
        public string Id { get; set; }
    }
}