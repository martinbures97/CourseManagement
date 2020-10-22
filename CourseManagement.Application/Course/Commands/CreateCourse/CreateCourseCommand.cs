using MediatR;

namespace CourseManagement.Application.Course.Commands.CreateCourse
{
    public sealed class CreateCourseCommand : IRequest<object>
    {
        public string Name { get; set; }
        public string TeacherId { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }

        public string[] StudentIds { get; set; }
    }
}