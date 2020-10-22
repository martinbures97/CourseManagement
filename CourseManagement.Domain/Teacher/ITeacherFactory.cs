namespace CourseManagement.Domain
{
    public interface ITeacherFactory
    {
        Teacher NewTeacher(string name);
    }
}