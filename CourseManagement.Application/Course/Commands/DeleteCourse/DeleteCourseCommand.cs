using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Course.Commands.DeleteCourse
{
    public sealed class DeleteCourseCommand : IRequest, IIdRequest
    {
        public string Id { get; set; }
    }
}