using CourseManagement.Domain.Common.Interfaces;
using System;

namespace CourseManagement.Domain.Common
{
    public abstract class AuditableEntity :
        Entity,
        IAddableEntity,
        IUpdatableEntity,
        ISoftDeletableEntity,
        IEquatable<AuditableEntity>
    {
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string UpdatedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string DeletedBy { get; private set; }

        public bool Equals(AuditableEntity other)
        {
            return Id.Equals(other.Id);
        }
    }
}