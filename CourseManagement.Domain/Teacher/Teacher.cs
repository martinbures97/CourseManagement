using CourseManagement.Domain.Common;
using System.Collections.Generic;

namespace CourseManagement.Domain
{
    public sealed class Teacher : PersonBase
    {
        internal Teacher(string name) : base(name)
        {
        }

        private Teacher() : base()
        {
        }

        public IReadOnlyCollection<Course> Courses { get; }
    }
}