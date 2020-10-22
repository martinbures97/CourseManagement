namespace CourseManagement.Domain
{
    public sealed class CourseFactory : ICourseFactory
    {
        public Course NewCourse(string name, int maxCapacity)
        {
            return new Course(name, maxCapacity);
        }
    }
}