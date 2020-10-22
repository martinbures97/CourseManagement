using System;

namespace CourseManagement.Domain.Common.Interfaces
{
    public interface IUpdatableEntity : IEntity
    {
        public DateTime? UpdatedOn { get; }
        public string UpdatedBy { get; }
    }
}