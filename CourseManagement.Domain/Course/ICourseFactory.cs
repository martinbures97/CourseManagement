namespace CourseManagement.Domain
{
    public interface ICourseFactory
    {
        Course NewCourse(string name, int maxCapacity);
    }
}