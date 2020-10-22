using Microsoft.Extensions.DependencyInjection;
using System;

namespace CourseManagement.Domain.UnitTests
{
    public abstract class TestBase
    {
        public IServiceProvider ServiceProvider;

        public void RunBeforeAnyTest()
        {
            var services = new ServiceCollection();

            services.AddTransient<ICourseFactory, CourseFactory>();
            services.AddTransient<IStudentFactory, StudentFactory>();
            services.AddTransient<ITeacherFactory, TeacherFactory>();


            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
