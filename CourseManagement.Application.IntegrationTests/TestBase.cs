using CourseManagement.API;
using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using CourseManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.IO;
using System.Linq;

namespace CourseManagement.Application.IntegrationTests
{
    public abstract class TestBase
    {
        public IMediator mediator;
        public IServiceProvider ServiceProvider;
        public string UserId;
        public string Username;
        public ITeacherService TeacherService;
        public ITeacherFactory TeacherFactory;
        public IStudentService StudentService;
        public IStudentFactory StudentFactory;
        public ICourseService CourseService;
        public ICourseFactory CourseFactory;
        public IUnitOfWork UnitOfWork;
        public IDbContextQueryAccessor DbContextQueryAccessor;

        public void RunBeforeAnyTest()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

            var configuration = builder.Build();
            var startup = new Startup(configuration);
            var services = new ServiceCollection();
            services.AddLogging();
            startup.ConfigureServices(services);

            var identityServiceDescriptor = services.FirstOrDefault(d => d.ServiceType == typeof(IIdentityService));
            services.Remove(identityServiceDescriptor);
            services.AddTransient(provider => Mock.Of<IIdentityService>(s => s.UserId == UserId));

            ServiceProvider = services.BuildServiceProvider();

            mediator = (IMediator)ServiceProvider.GetService(typeof(IMediator));

            DbContextQueryAccessor = (IDbContextQueryAccessor)ServiceProvider.GetService(typeof(IDbContextQueryAccessor));

            UnitOfWork = (IUnitOfWork)ServiceProvider.GetService(typeof(IUnitOfWork));
            TeacherFactory = (ITeacherFactory)ServiceProvider.GetService(typeof(ITeacherFactory));
            TeacherService = (ITeacherService)ServiceProvider.GetService(typeof(ITeacherService));
            StudentFactory = (IStudentFactory)ServiceProvider.GetService(typeof(IStudentFactory));
            StudentService = (IStudentService)ServiceProvider.GetService(typeof(IStudentService));
            CourseFactory = (ICourseFactory)ServiceProvider.GetService(typeof(ICourseFactory));
            CourseService = (ICourseService)ServiceProvider.GetService(typeof(ICourseService));

            ReinitDatabase();
            CreateUser("Test" + Guid.NewGuid().ToString(), "1asd6541a61Z_");
        }

        private void CreateUser(string userName, string password)
        {
            var userManager = ServiceProvider.GetService<UserManager<IdentityUser>>();

            var user = new IdentityUser { UserName = userName, Email = userName };

            var result = userManager.CreateAsync(user, password).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                UserId = user.Id;
                Username = user.UserName;
            }
            else
            {
                throw new Exception($"Unable to create {userName}");
            }
        }
        public void ReinitDatabase()
        {
            var dbContext = (CourseManagementDbContext)ServiceProvider.GetService(typeof(CourseManagementDbContext));

            dbContext.Database.EnsureCreated();
        }
    }
}
