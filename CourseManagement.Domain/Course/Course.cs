using CourseManagement.Domain.Common;
using CourseManagement.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagement.Domain
{
    public sealed class Course : AuditableEntity
    {
        private readonly List<CourseStudent> _courseStudents = new List<CourseStudent>();

        internal Course(
            string name,
            int maxCapacity)
        {
            SetName(name);
            SetCapacity(maxCapacity);
        }

        private Course()
        {
        }

        public string Description { get; private set; }
        public int MaxCapacity { get; private set; }
        public string Name { get; private set; }
        public string TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }
        public IReadOnlyCollection<CourseStudent> CourseStudents => _courseStudents.AsReadOnly();

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            }

            Name = name;
        }

        public void SetTeacher(Teacher teacher)
        {
            Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
            TeacherId = teacher.Id;
        }
        public void DeleteTeacher(Teacher teacher)
        {
            Teacher = null;
            TeacherId = null;
        }

        public void SetCapacity(int capacity)
        {
            if (capacity.Equals(0))
            {
                throw new DomainLayerException("Course capacity can't be set to 0");
            }

            if (_courseStudents.Count > capacity)
            {
                throw new DomainLayerException("Maximum student capacity can't be lower than current number of students assigned to this course.");
            }

            MaxCapacity = capacity;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void AddStudent(Student student)
        {
            if (_courseStudents.Count.Equals(MaxCapacity))
            {
                throw new DomainLayerException("The maximum capacity of students in the course has already been reached.");
            }

            if (_courseStudents.Any(x => x.CourseId.Equals(Id) && x.StudentId.Equals(student.Id)))
            {
                throw new DomainLayerException($"Student {student} is already assigned to this course. Unable to add.");
            }

            _courseStudents.Add(new CourseStudent(this, student));
        }

        public void DeleteStudent(Student student)
        {
            var courseStudent = _courseStudents.FirstOrDefault(x => x.CourseId == Id && x.StudentId == student.Id);
            if (courseStudent is null)
            {
                throw new DomainLayerException($"Student {student} is not assigned to this course {this}. Unable to delete.");
            }

            _courseStudents.Remove(courseStudent);
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}