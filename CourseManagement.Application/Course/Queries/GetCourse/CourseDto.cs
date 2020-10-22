using System;

namespace CourseManagement.Application.Course.Queries.GetCourse
{
    public sealed class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }
        public int MaxCapacity { get; set; }
        public string Description { get; set; }
        public string[] StudentIds { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}