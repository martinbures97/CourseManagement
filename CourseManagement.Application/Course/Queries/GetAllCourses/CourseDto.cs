namespace CourseManagement.Application.Course.Queries.GetAllCourses
{
    public sealed class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }
        public int MaxCapacity { get; set; }
        public string Description { get; set; }
        public string[] StudentIds { get; set; }
    }
}