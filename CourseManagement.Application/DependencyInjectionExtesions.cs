using CourseManagement.Application.Behaviours;
using CourseManagement.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CourseManagement.Application
{
    public static class DependencyInjectionExtesions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<ITeacherFactory, TeacherFactory>();
            services.AddTransient<IStudentFactory, StudentFactory>();
            services.AddTransient<ICourseFactory, CourseFactory>();
            return services;
        }
    }
}