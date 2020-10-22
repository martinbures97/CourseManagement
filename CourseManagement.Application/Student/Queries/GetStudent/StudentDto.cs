using System;

namespace CourseManagement.Application.Student.Queries.GetStudent
{
    public sealed class StudentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string[] CourseIds { get; set; }
    }
}