using System;

namespace CourseManagement.Domain.Common.Interfaces
{
    public interface ISoftDeletableEntity : IEntity
    {
        public DateTime? DeletedOn { get; }
        public string DeletedBy { get; }
    }
}