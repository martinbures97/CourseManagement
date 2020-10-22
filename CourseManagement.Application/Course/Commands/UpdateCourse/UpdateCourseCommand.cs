using CourseManagement.Application.Abstraction;
using MediatR;

namespace CourseManagement.Application.Course.Commands.UpdateCourse
{
    public sealed class UpdateCourseCommand : IRequest, IIdRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }
        public string[] StudentIds { get; set; }
    }
}