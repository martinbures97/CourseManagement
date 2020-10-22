using System;

namespace CourseManagement.Domain.Common.Interfaces
{
    public interface IAddableEntity : IEntity
    {
        public DateTime CreatedOn { get; }
        public string CreatedBy { get; }
    }
}