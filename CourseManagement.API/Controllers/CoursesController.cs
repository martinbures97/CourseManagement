using CourseManagement.Application.Course.Commands.CreateCourse;
using CourseManagement.Application.Course.Commands.DeleteCourse;
using CourseManagement.Application.Course.Commands.UpdateCourse;
using CourseManagement.Application.Course.Queries.GetAllCourses;
using CourseManagement.Application.Course.Queries.GetCourse;
using Microsoft.AspNetCore.Authorization;

namespace CourseManagement.API.Controllers
{
    [Authorize]
    public class CoursesController : CrudApiController<CreateCourseCommand, GetCourseQuery, GetAllCoursesQuery, UpdateCourseCommand, DeleteCourseCommand>
    {
    }
}