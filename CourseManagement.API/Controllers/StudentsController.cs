using CourseManagement.Application.Student.Commands.CreateStudent;
using CourseManagement.Application.Student.Commands.DeleteStudent;
using CourseManagement.Application.Student.Commands.UpdateStudent;
using CourseManagement.Application.Student.Queries.GetAllStudents;
using CourseManagement.Application.Student.Queries.GetStudent;
using Microsoft.AspNetCore.Authorization;

namespace CourseManagement.API.Controllers
{
    [Authorize]
    public class StudentsController : CrudApiController<CreateStudentCommand, GetStudentQuery, GetAllStudentsQuery, UpdateStudentCommand, DeleteStudentCommand>
    {
    }
}