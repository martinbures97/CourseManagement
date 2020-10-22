using AutoMapper;
using CourseManagement.Application;
using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using CourseManagement.Infrastructure.Automapper;
using CourseManagement.Infrastructure.EntityFramework;
using CourseManagement.Infrastructure.Identity;
using CourseManagement.Infrastructure.Persistence;
using CourseManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CourseManagement.Infrastructure
{
    public static class DependecyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ApplicationLayer).Assembly);

            services.AddTransient<IUnitOfWork, EntityFrameworkUnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();

            services.AddSingleton<IDateTimeService, LocalDateTimeService>();
            services.AddSingleton<IIdentityService, AspNetIdentityService>();

            services.AddTransient<IToListAsyncWrapper, EntityFrameworkToListAsyncWrapper>();
            services.AddTransient<IDbContextQueryAccessor, CourseManagementDbContext>();

            services.AddTransient<IUserService, AspnetIdentityUserService>();

            services.AddTransient(typeof(IEntityToDtoMapper<>), typeof(AutomapperEntityToDtoMapper<>));

            if (bool.Parse(configuration["Db:UseInMemory"]))
            {
                services.UseInMemoryDb(Guid.NewGuid().ToString());
            }
            else
            {
                services.UseSqlServerDb(configuration);
            }


            return services;
        }

        private static IServiceCollection UseSqlServerDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CourseManagementDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CourseManagementConnectionString"));
            });

            services.AddDbContext<CourseManagementIdentityDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CourseManagementConnectionString"));
            });

            return services;
        }

        private static IServiceCollection UseInMemoryDb(this IServiceCollection services, string dbName)
        {
            services.AddDbContext<CourseManagementDbContext>((options) =>
            {
                options.UseInMemoryDatabase(dbName);
            });

            services.AddDbContext<CourseManagementIdentityDbContext>((options) =>
            {
                options.UseInMemoryDatabase(dbName);
            });

            return services;
        }
    }
}