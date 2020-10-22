using AutoMapper;
using System.Linq;

namespace CourseManagement.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappings();
        }

        private void ApplyMappings()
        {
            CreateMap<Domain.Teacher, Teacher.Queries.GetAllTeachers.TeacherDto>();
            CreateMap<Domain.Teacher, Teacher.Queries.GetTeacher.TeacherDto>()
                .ForMember(x => x.CourseIds, x => x.MapFrom(x => x.Courses.Select(x => x.Id)));

            CreateMap<Domain.Student, Student.Queries.GetStudent.StudentDto>()
                .ForMember(x => x.CourseIds, x => x.MapFrom(x => x.CourseStudents.Select(x => x.CourseId)));

            CreateMap<Domain.Student, Student.Queries.GetAllStudents.StudentDto>();

            CreateMap<Domain.Course, Course.Queries.GetAllCourses.CourseDto>()
              .ForMember(x => x.StudentIds, x => x.MapFrom(x => x.CourseStudents.Select(x => x.StudentId)));
            CreateMap<Domain.Course, Course.Queries.GetCourse.CourseDto>()
             .ForMember(x => x.StudentIds, x => x.MapFrom(x => x.CourseStudents.Select(x => x.StudentId)));
        }
    }
}