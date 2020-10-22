namespace CourseManagement.Domain
{
    public class TeacherFactory : ITeacherFactory
    {
        public Teacher NewTeacher(string name)
        {
            return new Teacher(name);
        }
    }
}