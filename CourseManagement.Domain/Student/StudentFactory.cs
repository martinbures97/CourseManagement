namespace CourseManagement.Domain
{
    public sealed class StudentFactory : IStudentFactory
    {
        public Student NewStudent(string name)
        {
            return new Student(name);
        }
    }
}