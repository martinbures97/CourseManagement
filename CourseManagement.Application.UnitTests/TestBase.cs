using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using CourseManagement.Infrastructure.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CouseManagement.Application.UnitTests
{
    public abstract class TestBase
    {
        public IServiceProvider ServiceProvider;

        public void RunBeforeAnyTest()
        {
            var services = new ServiceCollection();

            services.AddTransient(typeof(IRepository<>), typeof(FakeRepository<>));
            services.AddTransient<ITeacherFactory, TeacherFactory>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
