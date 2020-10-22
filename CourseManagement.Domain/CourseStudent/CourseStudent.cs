using System;

namespace CourseManagement.Domain
{
    public sealed class CourseStudent
    {
        internal CourseStudent(
            Course course,
            Student student)
        {
            Student = student ?? throw new ArgumentNullException(nameof(student));
            StudentId = student.Id;
            Course = course ?? throw new ArgumentNullException(nameof(course));
            CourseId = course.Id;
        }

        private CourseStudent()
        {
        }

        public string StudentId { get; }
        public Student Student { get; }

        public string CourseId { get; }
        public Course Course { get; }
    }
}