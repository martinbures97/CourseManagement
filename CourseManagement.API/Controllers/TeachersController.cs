using CourseManagement.Application.Teacher.Commands.CreateTeacher;
using CourseManagement.Application.Teacher.Commands.DeleteTeacher;
using CourseManagement.Application.Teacher.Commands.UpdateTeacher;
using CourseManagement.Application.Teacher.Queries.GetAllTeachers;
using CourseManagement.Application.Teacher.Queries.GetTeacher;
using Microsoft.AspNetCore.Authorization;

namespace CourseManagement.API.Controllers
{
    [Authorize]
    public class TeachersController : CrudApiController<CreateTeacherCommand, GetTeacherQuery, GetAllTeachersQuery, UpdateTeacherCommand, DeleteTeacherCommand>
    {
    }
}