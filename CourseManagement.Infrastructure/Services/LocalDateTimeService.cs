using CourseManagement.Application.Abstraction;
using System;

namespace CourseManagement.Infrastructure.Services
{
    public sealed class LocalDateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}