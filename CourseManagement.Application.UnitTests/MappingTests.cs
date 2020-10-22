using AutoMapper;
using CourseManagement.Application.Course.Queries.GetAllCourses;
using CourseManagement.Application.Mapping;
using CourseManagement.Application.Student.Queries.GetAllStudents;
using CourseManagement.Application.Teacher.Queries.GetAllTeachers;
using CourseManagement.Domain;
using System;
using Xunit;

namespace CouseManagement.Application.UnitTests
{
    public class MappingTests
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        public MappingTests()
        {
            _configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configurationProvider.CreateMapper();
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configurationProvider.AssertConfigurationIsValid();
        }


        [Theory]
        [InlineData(typeof(Teacher), typeof(TeacherDto))]
        [InlineData(typeof(Course), typeof(CourseDto))]
        [InlineData(typeof(Student), typeof(StudentDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            _mapper.Map(source, destination);
        }
    }
}
