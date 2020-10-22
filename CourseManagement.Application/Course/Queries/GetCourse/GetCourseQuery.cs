using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Course.Queries.GetCourse
{
    public sealed class GetCourseQuery : IRequest<CourseDto>, IIdRequest
    {
        public string Id { get; set; }
    }
}