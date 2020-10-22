using System;

namespace CourseManagement.Domain.Common
{
    public abstract class PersonBase : AuditableEntity
    {
        protected PersonBase(string name) : base()
        {
            SetName(name);
        }

        protected PersonBase()
        {
        }

        public string Name { get; private set; }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}