using CourseManagement.Domain.Common;
using System.Collections.Generic;

namespace CourseManagement.Domain
{
    public sealed class Student : PersonBase
    {
        internal Student(string name) : base(name)
        {
        }

        private Student() : base()
        {
        }

        public IReadOnlyCollection<CourseStudent> CourseStudents { get; }
    }
}