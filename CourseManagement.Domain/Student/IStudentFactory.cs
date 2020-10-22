namespace CourseManagement.Domain
{
    public interface IStudentFactory
    {
        Student NewStudent(string name);
    }
}