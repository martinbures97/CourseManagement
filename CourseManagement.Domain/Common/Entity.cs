using CourseManagement.Domain.Common.Interfaces;

namespace CourseManagement.Domain.Common
{
    public abstract class Entity : IEntity
    {
        public string Id { get; }
    }
}