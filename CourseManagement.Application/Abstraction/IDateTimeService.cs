using System;

namespace CourseManagement.Application.Abstraction
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
    }
}